using IdentityServer.Common;
using IdentityServer.Data.Entity;
using IdentityServer.Data.Identity;
using IdentityServer.Models;
using IdentityServer.Models.Account;
using IdentityServer.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.Account.PermissionBusiness
{
    [Route("api/identity/account-manage")]
    public class AccountManageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _AppDbContext;
        public AccountManageController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            AppDbContext AppDbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _AppDbContext = AppDbContext;

        }

        [HttpGet]
        [Route("create-account-test")]
        public async Task<IActionResult> CreateAccountTest()
        {
            //var model = new AppUser();
            //model.UserName = "code01";
            //model.Email = "code01@gmail.com";
            //model.PhoneNumber = "0837911078";
            //model.EmailConfirmed = true;
            //model.IsAdmin = true;
            //model.Address = "123454";
            //model.DepartmentId = Guid.Parse("297c57a7-44a8-4069-b4bc-6a15169fdb35");
            //model.JobTitleId = Guid.Parse("31fe50cd-1c65-4ea4-bb78-0ed520fc3b22");
            //var result = await _userManager.CreateAsync(model, "123456789");
            //return Ok(1);
            var model = new AppUser();
            model.Id = Guid.NewGuid().ToString();
            model.UserName = "admin1@gmail.com";
            model.Email = "admin1@gmail.com";
            model.PhoneNumber = "0837911078";
            model.EmailConfirmed = true;
            model.IsAdmin = true;
            model.Address = "123454";
            model.DepartmentId = Guid.Parse("2cd561ec-22da-479e-8928-1c702db734a2");
            model.JobTitleId = Guid.Parse("97fa6e53-af0f-4a71-940a-1772758ad23e");
            var result = await _userManager.CreateAsync(model, "123456789");
            return Ok(1);

        }

        [HttpPost]
        [Route("create-account-admin")]
        public async Task<IActionResult> CreateAccountAdmin(AddUserModal user)
        {
            var model = new AppUser();
            model.Id = Guid.NewGuid().ToString();
            model.UserName = "admin1@gmail.com";
            model.Email = "admin1@gmail.com";
            model.PhoneNumber = "0837911078";
            model.EmailConfirmed = true;
            model.IsAdmin = true;
            model.Address = "123454";
            model.DepartmentId = Guid.Parse("2cd561ec-22da-479e-8928-1c702db734a2");
            model.JobTitleId = Guid.Parse("97fa6e53-af0f-4a71-940a-1772758ad23e");
            var result = await _userManager.CreateAsync(model, "123456789");
            return Ok(1);
        }
        [HttpPost]
        [Route("save-user")]
        public async Task<ResponseApi> SaveUser([FromBody] SaveUserModal user)
        {
            try
            {

                var resultObj = new object();

                if (user.EntityStatus == 1)
                {
                    var FindUser = _userManager.FindByNameAsync(user.UserName);
                    if (FindUser == null)
                    {
                        var model = new AppUser();
                        model.UserName = user.Email;
                        model.Email = user.Email;
                        model.PhoneNumber = user.PhoneNumber;
                        model.EmailConfirmed = true;
                        model.IsAdmin = user.IsAdmin;
                        model.IsAdministrator = false;
                        model.Address = user.Address;
                        model.Description = user.Description;
                        model.DepartmentId = new Guid(user.DepartmentId);
                        model.JobTitleId = new Guid(user.JobTitleId);
                        model.FullName = user.FullName;
                        resultObj = await _userManager.CreateAsync(model, "123456aA@");
                    }
                }
                if (user.EntityStatus == 2)
                {
                    var FindUser = await _userManager.FindByNameAsync(user.UserName);
                    if (_userManager != null)
                    {
                        FindUser.UserName = user.Email;
                        FindUser.Email = user.Email;
                        FindUser.PhoneNumber = user.PhoneNumber;
                        FindUser.EmailConfirmed = true;
                        FindUser.IsAdmin = user.IsAdmin;
                        FindUser.IsAdministrator = false;
                        FindUser.Address = user.Address;
                        FindUser.Description = user.Description;
                        FindUser.DepartmentId = new Guid(user.DepartmentId);
                        FindUser.JobTitleId = new Guid(user.JobTitleId);
                        FindUser.FullName = user.FullName;

                        resultObj = await _userManager.UpdateAsync(FindUser);
                    }
                }

                return new ResponseApi
                {
                    Data = resultObj,
                    StatusCode = 1,
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
        [ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-list-account")]
        public async Task<ResponseApi> GetListAccountPagding([FromBody] PagingUser paging)
        {
            try
            {
                var IsAuthentication = User.Identity.IsAuthenticated;
                var listUserPage = _userManager.Users.Where(x => x.UserName.Contains(paging.KEY)).Skip((paging.PAGE_NUMBER - 1) * paging.PAGE_SIZE).Take(paging.PAGE_SIZE).ToList();
                paging.TOTAL_RECORD = _userManager.Users.Count();
                paging.listData = listUserPage;
                paging.listData.ForEach(x => x.PasswordHash = "");
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

        [HttpGet]
        //[ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-list-department")]
        public async Task<List<Department>> GetListDepartment()
        {
            var data = new List<Department>();
            try
            {
                //var list = _AppDbContext.departments.ToList();
                data = (from d in _AppDbContext.departments where d.status == 1 select d).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.Message);
            }
            return data;
        }

        [HttpGet]
        //[ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-list-user-by-department")]
        public async Task<List<UserMapResponse>> GetListUserByDepartment(string departmentId)
        {
            var listUserResponse = new List<UserMapResponse>();

            try
            {
                //var list = _AppDbContext.departments.ToList();
                var ListUser = (from u in _AppDbContext.Users where u.DepartmentId == new Guid(departmentId) select u).ToList();
                ListUser.ForEach(x =>
                {
                    var e = _AppDbContext.Entry(x);
                    e.Reference(p => p.jobTitle).Load();
                    e.Reference(p => p.department).Load();
                    var user = new UserMapResponse()
                    {
                        UserId = x.Id,
                        UserName = x.UserName,
                        JobTitleId = x.JobTitleId,
                        DepartmentId = x.DepartmentId,
                        JobTitleName = x.jobTitle.JobTitleName,
                        DepartmentName = x.department.DepartmentName

                    };
                    listUserResponse.Add(user);
                });

            }
            catch (Exception ex)
            {
                throw new Exception(ex?.Message);
            }
            return listUserResponse;
        }

        [HttpGet]
        //[ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-list-user-by-list-department")]
        public async Task<List<ListDeparmentUser>> GetListUserByListDepartment(string listDepartmentId)
        {
            var ListDeparmentUserResponse = new List<ListDeparmentUser>();
            try
            {
                var Departments = (from d in _AppDbContext.departments where listDepartmentId.Contains(d.DepartmentId.ToString()) select d).ToList();
                Departments?.ForEach(x =>
                {
                    var e = _AppDbContext.Entry(x);
                    e.Collection(p => p.appUsers).Load();

                    var lstUser = new List<UserMapResponse>();
                    x.appUsers?.ForEach(u =>
                    {
                        var h = _AppDbContext.Entry(u);
                        h.Reference(p => p.jobTitle).Load();
                        var user = new UserMapResponse()
                        {
                            DepartmentId = x.DepartmentId,
                            DepartmentName = x.DepartmentName,
                            UserId = u.Id,
                            UserName = u.UserName,
                            JobTitleId = u.JobTitleId,
                            JobTitleName = u.jobTitle.JobTitleName
                        };
                        lstUser.Add(user);
                    });
                    var item = new ListDeparmentUser()
                    {
                        DepartmentId = x.DepartmentId,
                        DepartmentName = x.DepartmentName,
                        Status = x.status,
                        appUsers = lstUser ?? null

                    };
                    ListDeparmentUserResponse.Add(item);
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.Message);
            }
            return ListDeparmentUserResponse;
        }

        [HttpGet]
        //[ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-department-jobtitle-by-users")]
        public async Task<List<UserMapResponse>> GetDepartmentJobtitle(string stringUserId)
        {
            var listUserResponse = new List<UserMapResponse>();
            try
            {
                //var listUser = _AppDbContext.Users.Select(p=>p.Id.Contains(stringUserId)).ToList();
                var ListUser = (from u in _AppDbContext.Users where stringUserId.Contains(u.Id) select u).ToList();
                ListUser.ForEach(x =>
                {
                    var e = _AppDbContext.Entry(x);
                    e.Reference(p => p.jobTitle).Load();
                    e.Reference(p => p.department).Load();
                    var user = new UserMapResponse()
                    {
                        UserId = x.Id,
                        UserName = x.UserName,
                        JobTitleId = x.JobTitleId,
                        DepartmentId = x.DepartmentId,
                        JobTitleName = x.jobTitle.JobTitleName,
                        DepartmentName = x.department.DepartmentName

                    };
                    listUserResponse.Add(user);
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.Message);
            }
            return listUserResponse;
        }

        [HttpGet]
        //[ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-list-user-for-department-by-users")]
        public async Task<List<ListDepartmentInfo>> GetListUserForDepartmentByUserId(string stringUserId)
        {
            //stringUserId = "322a5ac2-0079-4d11-ab12-1d8ce352ec1f,7d05f2b4-8877-44b6-ab1a-6dee3bd6bbfd,b7920511-8122-4d97-aca5-d0c41e523913,d57b5b12-7619-4445-bc2d-a99acdf2a4c7";

            var lstNew = new List<ListDepartmentInfo>();

            var listUserResponse = new List<UserMapResponse>();
            try
            {
                var Listdepartment = (from u in _AppDbContext.Users
                                      join d in _AppDbContext.departments on u.DepartmentId equals d.DepartmentId
                                      where stringUserId.Contains(u.Id)
                                      select d).ToList();
                if (Listdepartment != null && Listdepartment.Count > 0)
                {
                    Listdepartment.ForEach(d =>
                    {
                        var lstNewUser = new List<UserMapResponse>();
                        var e = _AppDbContext.Entry(d);
                        e.Collection(p => p.appUsers).Load();
                        d.appUsers.ForEach(u =>
                        {
                            var e = _AppDbContext.Entry(u);
                            e.Reference(p => p.jobTitle).Load();
                            e.Reference(p => p.department).Load();
                            var user = new UserMapResponse()
                            {
                                UserId = u.Id,
                                UserName = u.UserName,
                                JobTitleId = u.JobTitleId,
                                DepartmentId = u.DepartmentId,
                                JobTitleName = u.jobTitle.JobTitleName,
                                DepartmentName = u.department.DepartmentName
                            };
                            lstNewUser.Add(user);
                        });

                        var dep = new ListDepartmentInfo()
                        {
                            DepartmentId = d.DepartmentId,
                            DepartmentName = d.DepartmentName,
                            appUsers = lstNewUser,
                            status = d.status
                        };
                        lstNew.Add(dep);
                    });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex?.Message);
            }
            return lstNew;
        }

        [HttpGet]
        //[ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-common-dropdown")]
        public ResponseApi GetCommonDropDown(int type, string key = "")
        {
            var lstNew = new List<DropDownCommon>();

            if (string.IsNullOrEmpty(key))
            {
                key = "";
            }

            try
            {
                if (type == Models.Enum.TableDeparment)
                {

                    var Listdepartment = (from d in _AppDbContext.departments
                                          where d.DepartmentName.Contains(key)
                                          select d).Take(50).ToList();

                    if (Listdepartment != null && Listdepartment.Count > 0)
                    {
                        Listdepartment.ForEach(d =>
                        {
                            var item = new DropDownCommon()
                            {
                                label = d.DepartmentName,
                                value = d.DepartmentId.ToString()
                            };
                            lstNew.Add(item);
                        });
                    }
                }
                if (type == Models.Enum.TableJobTitle)
                {

                    var ListJobTitleName = (from d in _AppDbContext.jobTitles
                                            where d.JobTitleName.Contains(key)
                                            select d).Take(50).ToList();

                    if (ListJobTitleName != null && ListJobTitleName.Count > 0)
                    {
                        ListJobTitleName.ForEach(d =>
                        {
                            var item = new DropDownCommon()
                            {
                                label = d.JobTitleName,
                                value = d.JobTitleId.ToString()
                            };
                            lstNew.Add(item);
                        });
                    }
                }
                if (type == Models.Enum.TablePermission)
                {
                    var ListPermissionName = (from p in _AppDbContext.permissions
                                              where p.PermissionName.Contains(key)
                                              select p).Take(50).ToList();

                    if (ListPermissionName != null && ListPermissionName.Count > 0)
                    {
                        ListPermissionName.ForEach(d =>
                        {
                            var item = new DropDownCommon()
                            {
                                label = d.PermissionName,
                                value = d.PermissionsId.ToString()
                            };
                            lstNew.Add(item);
                        });
                    }
                }

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
            return new ResponseApi
            {
                Data = lstNew,
                StatusCode = 1,
                Message = "",
                Success = true
            };
        }

        [HttpPost]
        [ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-list-permission")]
        public async Task<ResponseApi> GetListPermissionPagding([FromBody] PagingPermission paging)
        {
            try
            {
                var IsAuthentication = User.Identity.IsAuthenticated;
                var listUserPage = _AppDbContext.permissions.Where
                    (x => x.PermissionName.Contains(paging.KEY)).Skip((paging.PAGE_NUMBER - 1) * paging.PAGE_SIZE).Take(paging.PAGE_SIZE).ToList();


                var lst = (from p in _AppDbContext.permissions
                           where p.PermissionName.Contains(paging.KEY)
                           select p)
                           .Skip((paging.PAGE_NUMBER - 1) * paging.PAGE_SIZE)
                           .Take(paging.PAGE_SIZE).ToList();

                paging.TOTAL_RECORD = _userManager.Users.Count();
                listUserPage.ForEach(x =>
                {
                    var Permission = new Permission()
                    {
                        PermissionsId = x.PermissionsId.ToString(),
                        PermissionName = x.PermissionName,
                        PermissionDescription = x.PermissionDescription,
                        Status = x.Status,

                    };
                    paging.listData.Add(Permission);
                });
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
        [Route("create-account-login-systemmes")]
        public async Task<ResponseApi> CreateAccountSysMes([FromBody] CreateAccountRequest user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Code.ToString()))
                {
                    return new ResponseApi
                    {
                        Data = (int)TypeMesCreateAccount.Account_UserName_Null,
                        StatusCode = 1,
                        Message = "success",
                        Success = true
                    };
                }
                var UserFind = await _userManager.FindByNameAsync(user.Code);
                if (UserFind != null)
                {

                    return new ResponseApi
                    {
                        Data = (int)TypeMesCreateAccount.Account_UserName_Exists,
                        StatusCode = 1,
                        Message = "success",
                        Success = true
                    };

                    //return (int)TypeMesCreateAccount.Account_UserName_Exists;
                }
                var model = new AppUser();
                model.Id = user.Id.ToString();
                model.UserName = user.Code;
                model.PhoneNumber = user.Phone;
                model.EmailConfirmed = true;
                model.IsAdmin = false;
                model.FullName = user.FullName;
                model.DepartmentId = Guid.Parse("2cd561ec-22da-479e-8928-1c702db734a2");
                model.JobTitleId = Guid.Parse("97fa6e53-af0f-4a71-940a-1772758ad23e");

                if (!string.IsNullOrEmpty(user.Email))
                {
                    model.Email = user.Email;
                }
                else
                {
                    model.Email = user.Code + "_evomessystem@gmail.com";
                }
                var result = await _userManager.CreateAsync(model, user.Password);
                if (result.Succeeded == true)
                {
                    return new ResponseApi
                    {
                        Data = (int)TypeMesCreateAccount.Account_UserName_Add_Success,
                        StatusCode = 1,
                        Message = "success",
                        Success = true
                    };
                }
                else
                {
                    return new ResponseApi
                    {
                        Data = (int)TypeMesCreateAccount.Account_UserName_Add_False,
                        StatusCode = 1,
                        Message = "success",
                        Success = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseApi
                {
                    Data = (int)TypeMesCreateAccount.Account_UserName_Add_Exception,
                    StatusCode = 1,
                    Message = "success",
                    Success = true
                };
            }
        }

        [HttpPost]
        [Route("create-account-resetpass-systemmes")]
        public async Task<ResponseApi> ResetPassAccountSysMes([FromBody] ResetPassword user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.AccountName.ToString()))
                {
                    return new ResponseApi
                    {
                        Data = (int)TypeMesResetPasswordAccount.Account_UserName_Null,
                        StatusCode = 1,
                        Message = "success",
                        Success = true
                    };
                }
                var UserFind = await _userManager.FindByNameAsync(user.AccountName);
                if (UserFind == null)
                {
                    return new ResponseApi
                    {
                        Data = (int)TypeMesResetPasswordAccount.Account_UserName_Not_Exists,
                        StatusCode = 1,
                        Message = "success",
                        Success = true
                    };
                }
                else
                {
                    var code = await _userManager.GeneratePasswordResetTokenAsync(UserFind);
                    var resetp = _userManager.ResetPasswordAsync(UserFind, code, user.Password);
                    if (resetp.Result.Succeeded)
                    {
                        return new ResponseApi
                        {
                            Data = (int)TypeMesResetPasswordAccount.Account_ResetPassword_Success,
                            StatusCode = 1,
                            Message = "success",
                            Success = true
                        };
                    }
                    return new ResponseApi
                    {
                        Data = (int)TypeMesResetPasswordAccount.Account_ResetPassword_False,
                        StatusCode = 1,
                        Message = "success",
                        Success = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseApi
                {
                    Data = (int)TypeMesResetPasswordAccount.Account_ResetPassword_Exception,
                    StatusCode = 1,
                    Message = "success",
                    Success = true
                };
            }
        }

        [HttpGet]
        [Route("create-account-resetpass-systemmes-a")]
        public async Task<string> GResetPassAccountSysMes()
        {
            try
            {
                var UserFind = await _userManager.FindByNameAsync("d1@gmail.com");
                if (UserFind == null)
                {
                    return "not found";
                }
                else
                {
                    // get code change password
                    var code = await _userManager.GeneratePasswordResetTokenAsync(UserFind);
                    var resetp = await _userManager.ResetPasswordAsync(UserFind, code, "123456789");
                    if (resetp != null && resetp.Succeeded == true)
                    {
                        return "true";
                    }
                    return "false";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Authorize]
        [Route("~/api/identity/account-manage/test-auth")]
        public async Task<IActionResult> TestAuth()
        {

            var IsAuthentication = User.Identity.IsAuthenticated;

            return Ok(1);
        }
    }
}
