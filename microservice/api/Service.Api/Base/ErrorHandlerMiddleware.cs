using Application.GetMap;
using Evo.Mes.Sop.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Evo.Mes.Sop.Api.Base
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                //SetCulture(context);
                await _next(context);
            }
            catch (Exception exception)
            {
                // start save log
                // code here

                // end save log
                var response = context.Response;
                response.ContentType = "application/json";

                switch (exception)
                {
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                // var result = JsonSerializer.Serialize(new { message = exception?.Message });
                var result = JsonSerializer.Serialize(new ResponseApi()
                {
                    message = exception?.Message,
                    data = null,
                    isSuccess = false
                });
                await response.WriteAsync(result);
            }
        }

        private void SetCulture(HttpContext context)
        {
            string getHeaderLangue = context?.Request?.Headers?["language"];
            if (string.IsNullOrEmpty(getHeaderLangue))
            {
                getHeaderLangue = "vi";
            }
            var currentLang = CurrentLang(context);
            if (getHeaderLangue != currentLang)
            {
                string culture = getHeaderLangue;
                context.Response.Cookies.Append(
                   CookieRequestCultureProvider.DefaultCookieName,
                   CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                   new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) }
               );
            }
        }

        private string CurrentLang(HttpContext context)
        {
            string lang = "vi";
            var requestCulture = context?.Features?.Get<IRequestCultureFeature>();

            if (requestCulture != null)
                lang = requestCulture.RequestCulture.UICulture.Name;
            return lang;
        }
    }
}
