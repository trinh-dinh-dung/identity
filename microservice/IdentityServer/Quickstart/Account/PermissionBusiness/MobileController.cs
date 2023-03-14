using IdentityModel.Client;
using IdentityServer.Models;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;
using System;
using IdentityServer4.Configuration;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using IdentityServer.Data.Entity;
using IdentityServer.Data.Identity;
using IdentityServer4;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.NetworkInformation;
using IdentityServer.Models.Mobile;

namespace IdentityServer.Quickstart.Account.PermissionBusiness
{
    [Route("api/identity/mobi")]
    [ApiController]
    public class MobileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _AppDbContext;
        private readonly IdentityServerTools _IdentityServerTools;
        public MobileController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IdentityServerTools IdentityServerTools,
            AppDbContext AppDbContext,
            IHttpClientFactory httpClientFactory
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _AppDbContext = AppDbContext;
            _IdentityServerTools = IdentityServerTools;
            _httpClientFactory = httpClientFactory;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login-mobile")]
        public async Task<ResponseApi> LoginAs(LoginModel request)
        {
            //var issuer = "https://authen.viecgicungco.com";
            //var token = await _IdentityServerTools.IssueJwtAsync(
            //    30000,
            //    issuer,
            //    new System.Security.Claims.Claim[1]
            //    {
            //         new System.Security.Claims.Claim("cpf", "cpf")
            //    }
            //);

            var datatoken = new datatoken()
            {
                token = "",
                refresh = "",
                ExpiresIn = 1
            };

            //request.UserName = "admin@gmail.com";
            //request.Password = "evomes!@#";

            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var client = _httpClientFactory.CreateClient();

                var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
                var disco = await client.GetDiscoveryDocumentAsync(url);

                if (disco.IsError) throw new Exception(disco.Error);

                var tokenClient = _httpClientFactory.CreateClient();

                var tokenResult = await tokenClient.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    Scope = "openid profile offline_access evo_mes_admin_api evo_mes_Maintain_Service_api evo_mes_sop_api evo_mes_upload_api",
                    ClientId = "evomes_mobile",
                    ClientSecret = "secret",
                    UserName = request.UserName,
                    Password = request.Password,
                });

                if (tokenResult.IsError)
                {
                    return new ResponseApi
                    {
                        Data = null,
                        StatusCode = 0,
                        Message = "false",
                        Success = false
                    };
                }
                else
                {
                    datatoken.token = tokenResult.AccessToken;
                    datatoken.refresh = tokenResult.RefreshToken;
                    datatoken.ExpiresIn = tokenResult.ExpiresIn;
                    return new ResponseApi
                    {
                        Data = datatoken,
                        StatusCode = 1,
                        Message = "success",
                        Success = true
                    };
                }
            }
            else
            {
                return new ResponseApi
                {
                    Data = null,
                    StatusCode = 0,
                    Message = "user name or pass false",
                    Success = false
                };
            }

        }


        [HttpPost]
        [Route("refresh-token")]
        public async Task<ResponseApi> RefreshToken(refreshTokenModelRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
            var disco = await client.GetDiscoveryDocumentAsync(url);
            if (disco.IsError) throw new Exception(disco.Error);
            var tokenResult = await client.RequestRefreshTokenAsync(new RefreshTokenRequest()
            {
                RefreshToken = request.refreshToken,
                GrantType = "refresh_token",
                ClientId = "evomes_mobile",
                ClientSecret = "secret",
                Address = disco.TokenEndpoint,
            });

            if (tokenResult.IsError)
            {
                return new ResponseApi
                {
                    Data = null,
                    StatusCode = 0,
                    Message = "false",
                    Success = false
                };
            }
            else
            {
                var datatoken = new datatoken()
                {
                    token = "",
                    refresh = "",
                    ExpiresIn = 1
                };
                datatoken.token = tokenResult.AccessToken;
                datatoken.refresh = tokenResult.RefreshToken;
                datatoken.ExpiresIn = tokenResult.ExpiresIn;
                return new ResponseApi
                {
                    Data = datatoken,
                    StatusCode = 1,
                    Message = "success",
                    Success = true
                };
            }

        }

    }
}
