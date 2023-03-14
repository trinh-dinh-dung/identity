using IdentityServer.Data.Entity;
using IdentityServer.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;

namespace IdentityServer.Security
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute, IActionFilter
    {
        private readonly AppDbContext _dbContext;
        public BasicAuthenticationAttribute(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var jwt = filterContext?.HttpContext?.Request?.Headers?["Authorization"].ToString();
                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadJwtToken(jwt.Substring("Bearer ".Length));
                if (string.IsNullOrEmpty(tokenS?.ToString()))
                {
                    filterContext.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
                }
                var clientID = tokenS.Claims.First(claim => claim.Type == "client_id").Value;
                var userID = tokenS.Claims.First(claim => claim.Type == "sub").Value;
                if (!string.IsNullOrEmpty(userID))
                {
                    var userInfo = _dbContext.Users.Where(x => x.Id == userID).FirstOrDefault();
                    if (userInfo == null)
                    {
                        filterContext.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
                    }
                    else
                    {
                        if (!userInfo.IsAdministrator && !userInfo.IsAdmin)
                        {
                            filterContext.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
                        }
                    }
                }

                if ((string.IsNullOrEmpty(clientID) && clientID == "admin") || string.IsNullOrEmpty(userID))
                {
                    filterContext.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
            }

        }
    }
}
