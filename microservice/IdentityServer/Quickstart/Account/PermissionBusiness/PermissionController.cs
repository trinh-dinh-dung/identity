using IdentityServer.Data.Entity;
using IdentityServer.Data.Identity;
using IdentityServer.Models;
using IdentityServer.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.Account.PermissionBusiness
{
    [Route("api/identity/permission")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _AppDbContext;


        public PermissionController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext AppDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _AppDbContext = AppDbContext;

        }

        [HttpPost]
        [ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-list-permission")]
        public async Task<ResponseApi> GetListPermissionPagding([FromBody] PagingPermission paging)
        {
            try
            {
                var IsAuthentication = User.Identity.IsAuthenticated;
                var PermissionPage = _AppDbContext.permissions.AsNoTracking().Where(x => x.PermissionName.Contains(paging.KEY)).Skip((paging.PAGE_NUMBER - 1) * paging.PAGE_SIZE).Take(paging.PAGE_SIZE).ToList();
                paging.TOTAL_RECORD = _AppDbContext.permissions.Count();
                paging.listData = null;
                if (PermissionPage != null && PermissionPage.Count > 0)
                {
                    var listData = new List<Permission>();
                    PermissionPage.ForEach(x =>
                    {
                        var Permission = new Permission()
                        {
                            PermissionsId = x.PermissionsId.ToString(),
                            PermissionName = x.PermissionName,
                            PermissionDescription = x.PermissionDescription,
                            Status = x.Status,
                        };
                        listData.Add(Permission);
                    });
                    paging.listData = listData;
                }


                return new ResponseApi
                {
                    Data = paging,
                    StatusCode = 0,
                    Message = "success",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseApi
                {
                    Data = null,
                    StatusCode = 0,
                    Message = ex.Message,
                    Success = false
                };
            }
        }


        [HttpPost]
        [Route("save-permission")]
        public async Task<ResponseApi> SaveUser([FromBody] Permission Permission)
        {
            try
            {
                if (string.IsNullOrEmpty(Permission.PermissionsId))
                {
                    var addmodal = new Permissions()
                    {
                        PermissionsId = new Guid(),
                        PermissionName = Permission.PermissionName,
                        PermissionDescription = Permission.PermissionDescription,
                        Status = Permission.Status,
                    };
                    _AppDbContext.permissions.Add(addmodal);
                    _AppDbContext.SaveChanges();
                }
                else
                {
                    var addmodal = new Permissions()
                    {
                        PermissionsId = Guid.Parse(Permission.PermissionsId),
                        PermissionName = Permission.PermissionName,
                        PermissionDescription = Permission.PermissionDescription,
                        Status = Permission.Status,
                    };
                    _AppDbContext.permissions.Update(addmodal);
                    _AppDbContext.Entry(addmodal).State = EntityState.Modified;
                    _AppDbContext.SaveChanges();
                }
                return new ResponseApi
                {
                    Data = true,
                    StatusCode = 1,
                    Message = "",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseApi
                {
                    Data = null,
                    StatusCode = 0,
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        [HttpGet]
        [Route("get-data-menu-action-by-permissionid/{PermissionsId}")]
        public async Task<ResponseApi> getDatamenuActionByPermission(string PermissionsId)
        {
            try
            {
                var listresult = new List<string>();
                var menuid = _AppDbContext.permissionMenus.Where(m => m.PermissionsId == Guid.Parse(PermissionsId)).GroupBy(m => m.MenuId).ToList();
                return new ResponseApi
                {
                    Data = listresult,
                    StatusCode = 0,
                    Message = "",
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseApi
                {
                    Data = null,
                    StatusCode = 4,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
        [HttpGet]
        [Route("get-all-permission/{userId}")]
        public async Task<ResponseApi> GetAllPermission(string userId)
        {
            try
            {
                var listPermission = _AppDbContext.permissions.ToList();
                var listPerByUser = _AppDbContext.userPermissions.Where(m => m.UserId == userId).Select(m => m.PermissionsId.ToString()).ToList();
                return new ResponseApi
                {
                    Data = new DataUserPermission()
                    {
                        listPerByUser = listPerByUser,
                        listPermissions = listPermission,
                    },
                    StatusCode = 0,
                    Message = "success",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseApi
                {
                    Data = null,
                    StatusCode = 0,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
        [HttpPost]
        [Route("save-user-permission")]
        public async Task<ResponseApi> SaveUserPermission([FromBody] linkPermissionUser request)
        {
            try
            {
                var sqlDelete = @"DELETE FROM userPermissions WHERE UserId = @userId";
                var Parameter = new SqlParameter("userId", Guid.Parse(request.userId));
                _AppDbContext.Database.ExecuteSqlRaw(sqlDelete, Parameter);
                if (request.listPermissions == null || request.listPermissions.Count == 0)
                {
                    return new ResponseApi
                    {
                        Data = true,
                        StatusCode = 1,
                        Message = "Success",
                        Success = true
                    };
                }
                foreach (var item in request.listPermissions)
                {
                    var dataInsert = new UserPermission()
                    {
                        Id = Guid.NewGuid(),
                        PermissionsId = Guid.Parse(item),
                        UserId = request.userId,
                    };
                    _AppDbContext.userPermissions.Add(dataInsert);
                }
                _AppDbContext.SaveChanges();
                return new ResponseApi
                {
                    Data = true,
                    StatusCode = 1,
                    Message = "Success",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseApi
                {
                    Data = null,
                    StatusCode = 0,
                    Message = ex.Message,
                    Success = false
                };
            }
        }

    }
}
