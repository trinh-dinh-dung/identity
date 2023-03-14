using Application.Common.Appsetting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace ApiService.Base
{
    public class BaseController: ControllerBase
    {
        private readonly IOptions<Appsettings> _appsettings;
        public BaseController(IOptions<Appsettings> appsettings = null)
        {
            _appsettings = appsettings;
        }

        protected string UserID
        {
            get
            {
                string userId = "";
                if (User.Identity.IsAuthenticated)
                {
                    var userClaims = ((ClaimsPrincipal)User).Claims;
                    var sellerClaim = userClaims.FirstOrDefault(uc => uc.Type.Equals(ClaimTypes.NameIdentifier));
                    if (sellerClaim != null)
                    {
                        userId = sellerClaim.Value != null ? sellerClaim.Value : "";
                    }
                }
                return userId;
            }
        }

        protected string AccessToken
        {
            get
            {
                string authorizationToken = "";
                if (User.Identity.IsAuthenticated)
                {
                    authorizationToken = HttpContext?.Request?.Headers?["Authorization"];
                }
                return authorizationToken;
            }
        }


        protected string CurrentLang
        {
            get
            {
                string lang = "vi";
                var requestCulture = HttpContext?.Features?.Get<IRequestCultureFeature>();

                if (requestCulture != null)
                    lang = requestCulture.RequestCulture.UICulture.Name;
                return lang;
            }
        }

        /// <summary>
        /// SetCulture
        /// </summary>
        /// <param name="id"></param>
        protected void SetCulture()
        {
            var getHeaderLangue = HttpContext?.Request?.Headers?["language"];
            var currentLang = CurrentLang;
            if (!string.IsNullOrEmpty(getHeaderLangue) && getHeaderLangue.ToString() != currentLang)
            {
                string culture = getHeaderLangue;
                Response.Cookies.Append(
                   CookieRequestCultureProvider.DefaultCookieName,
                   CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                   new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) }
               );
            }
        }

        protected ResultApp callApiService(string api, Method method, object dataObject = null)
        {
            try
            {
                var client = new RestClient
                {

                    BaseUrl = new Uri(_appsettings.Value.Api_Gateway)
                };
                var request = new RestRequest(api, method) { RequestFormat = DataFormat.Json };
                if (User != null)
                {
                    //request.AddHeader("Authorization", string.Format("Bearer {0}", AccessToken));
                    request.AddHeader("Authorization", string.Format(AccessToken));
                    request.AddHeader("Accept", "application/json");
                }
                if (dataObject != null)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    request.AddBody(dataObject);
#pragma warning restore CS0618 // Type or member is obsolete
                    //request.AddObject(dataObject);
                }
                var response = client.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new ResultApp()
                    {
                        Success = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.StatusDescription
                    };
                }
                var result = response.Content;
                return new ResultApp()
                {
                    Success = true,
                    Data = result,
                    StatusCode = (int)response.StatusCode,
                    Message = response.StatusDescription
                };
            }
            catch (Exception e)
            {
                return new ResultApp()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = e.Message,
                    Data = e.Data
                };
            }
        }

        public class ResultApp
        {
            public object Data { get; set; }
            public int StatusCode { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }
            public string MesageStatus { get; set; }
        }
    }
}
