using IdentityServer.Common;
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
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.Account.PermissionBusiness
{
    [Route("api/identity/menu-manage")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _AppDbContext;


        public MenuController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext AppDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _AppDbContext = AppDbContext;

        }


        [HttpPost]
        //[ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-list-menu")]
        public async Task<ResponseApi> GetListMenuPagding([FromBody] PagingMenu paging)
        {
            try
            {
                var IsAuthentication = User.Identity.IsAuthenticated;
                var PermissionPage = new List<Menu>();
                if (!string.IsNullOrEmpty(paging.Parent))
                {
                    var sqlQueryString = _AppDbContext.menus.Where(m => m.Parent == Guid.Parse(paging.Parent)).OrderBy(x => x.sortOrder).ToList();
                    PermissionPage = _AppDbContext.menus.Where(m => m.Parent == Guid.Parse(paging.Parent)).OrderBy(x => x.sortOrder).ToList();
                }
                else
                {
                    Expression<Func<Menu, bool>> whereExpression = null;
                    if (paging.Parent == "")
                        paging.Parent = null;
                    whereExpression = x => x.Parent.ToString() == paging.Parent || x.Parent.ToString() == "";
                    // get Parent == 0 => menu phân hệ
                    PermissionPage = _AppDbContext.menus
                      .Where(whereExpression).Include(x => x.actionMenus)
                      .OrderBy(x => x.sortOrder)
                      .Skip((paging.PAGE_NUMBER - 1) * paging.PAGE_SIZE)
                      .Take(paging.PAGE_SIZE).ToList();
                }
                paging.TOTAL_RECORD = _AppDbContext.menus.Count();
                paging.listData = null;
                if (PermissionPage != null && PermissionPage.Count > 0)
                {

                    var listActionMenu = new List<ActionMenuModel>();

                    var listData = new List<MenuModel>();
                    PermissionPage.ForEach(x =>
                    {
                        if (x.actionMenus != null && x.actionMenus.Count > 0)
                        {
                            x.actionMenus.ForEach(am =>
                            {
                                var menuAction = new ActionMenuModel()
                                {
                                    Id = am.Id.ToString(),
                                    ActionName = am.ActionName,
                                    ActionTitle = am.ActionTitle,
                                    PathName = am.PathName,
                                    ActionCodeApi = am.ActionCodeApi,
                                    IsActive = am.IsActive,
                                    Status = am.Status,
                                    MenuId = am.MenuId.ToString(),
                                };
                                listActionMenu.Add(menuAction);
                            });
                        }
                        var Permission = new MenuModel()
                        {
                            MenuId = x.MenuId.ToString(),
                            MenuName = x.MenuName,
                            MenuTitle = x.MenuTitle,
                            MenuType = x.MenuType,
                            Parent = x.Parent.ToString(),
                            ActionApi = x.ActionApi,
                            ActionCode = x.ActionCode,
                            Status = x.Status,
                            ActionMenu = listActionMenu,
                            IsMenuAction = x.IsMenuAction,
                            IsHorizontal = x.IsHorizontal,
                            Islevel = x.Islevel,
                            comPath = x.comPath,
                            IsDefault = x.IsDefault,
                            path = x.path,
                            imagePath = x.imagePath,
                            sortOrder = x.sortOrder ?? 0,
                        };
                        listData.Add(Permission);
                    });
                    paging.listData = listData;
                }

                return new ResponseApi
                {
                    Data = paging,
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
        //[ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("save-menu")]
        public async Task<ResponseApi> SaveMenu([FromBody] MenuModel data)
        {
            try
            {
                var IsAuthentication = User.Identity.IsAuthenticated;

                if (data.EntityStatus == 1 || string.IsNullOrEmpty(data.MenuId))// thêm mới
                {
                    data.MenuId = Guid.NewGuid().ToString();
                    var menuSave = new Menu()
                    {
                        ActionApi = data.ActionApi,
                        MenuId = Guid.Parse(data.MenuId),
                        MenuName = data.MenuName,
                        MenuType = data.MenuType,
                        ActionCode = data.ActionCode,
                        MenuTitle = data.MenuTitle,
                        Status = data.Status,
                        IsMenuAction = data.IsMenuAction,
                        IsHorizontal = data.IsHorizontal,
                        Islevel = data.Islevel,
                        comPath = data.comPath ?? "",
                        IsDefault = data.IsDefault ?? false,
                        path = data.path ?? "",
                        imagePath = data.imagePath ?? "",
                        sortOrder = data.sortOrder,
                    };
                    if (data.Parent != null && data.Parent != "")
                    {
                        menuSave.Parent = Guid.Parse(data.Parent);
                    }
                    _AppDbContext.menus.Add(menuSave);
                    _AppDbContext.SaveChanges();
                }
                else
                {
                    var findMenu = _AppDbContext.menus
                        .AsTracking()
                        .Where(x => x.MenuId.Equals(Guid.Parse(data.MenuId)))
                        .FirstOrDefault();
                    if (findMenu != null)
                    {
                        findMenu.ActionApi = data.ActionApi;
                        findMenu.MenuId = Guid.Parse(data.MenuId);
                        findMenu.MenuName = data.MenuName;
                        findMenu.MenuType = data.MenuType;
                        findMenu.ActionCode = data.ActionCode;
                        findMenu.MenuTitle = data.MenuTitle;
                        findMenu.path = data.path ?? "";
                        findMenu.comPath = data.comPath ?? "";
                        findMenu.IsDefault = data.IsDefault ?? false;
                        findMenu.imagePath = data.imagePath ?? "";
                        findMenu.sortOrder = data.sortOrder;
                        if (data.Parent != null && data.Parent != "")
                        {
                            findMenu.Parent = Guid.Parse(data.Parent);
                        }
                        findMenu.IsMenuAction = data.IsMenuAction;
                        findMenu.IsHorizontal = data.IsHorizontal;
                        //findMenu.Status = data.Status;
                        //var menuSave = new Menu()
                        //{
                        //    ActionApi = data.ActionApi,
                        //    MenuId = Guid.Parse(data.MenuId),
                        //    MenuName = data.MenuName,
                        //    MenuType = data.MenuType,
                        //    ActionCode = data.ActionCode,
                        //    MenuTitle = data.MenuTitle,
                        //    Parent = data.Parent,
                        //    Status = data.Status,
                        //};
                        //_AppDbContext.Entry(findMenu).State = EntityState.Detached;

                        _AppDbContext.menus.Update(findMenu);
                        _AppDbContext.SaveChanges();
                    }
                }
                return new ResponseApi
                {
                    Data = 1,
                    StatusCode = 0,
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
        [Route("delete-menu/{MenuID}")]
        public async Task<ResponseApi> DeleteMenu(string MenuID)
        {
            try
            {
                if (!string.IsNullOrEmpty(MenuID))
                {
                    var findMenu = _AppDbContext.menus.AsTracking().Where(x => x.MenuId.Equals(Guid.Parse(MenuID))).FirstOrDefault();
                    //Expression<Func<Menu, bool>> whereExpression = null;


                    if (findMenu != null)
                    {
                        // xóa menu phân hệ
                        if (findMenu.MenuType == (int)TypeMenu.menu_subsystems || findMenu.MenuType == (int)TypeMenu.menu_item)
                        {
                            var menuItem = _AppDbContext.menus.AsTracking().Where(x => x.Parent.Equals(MenuID)).ToList();
                            if (menuItem != null && menuItem.Count > 0) // tồn tại menu con và acion
                            {
                                return new ResponseApi
                                {
                                    Data = 1,
                                    StatusCode = 0,
                                    Message = "Không thể xóa!",
                                    Success = true
                                };
                            }
                        }
                        _AppDbContext.menus.Remove(findMenu);
                        _AppDbContext.SaveChanges();
                        return new ResponseApi
                        {
                            Data = 1,
                            StatusCode = 0,
                            Message = "",
                            Success = true
                        };
                    }
                    return new ResponseApi
                    {
                        Data = null,
                        StatusCode = 0,
                        Message = "not find menu",
                        Success = false
                    };
                }
                return new ResponseApi
                {
                    Data = null,
                    StatusCode = 0,
                    Message = "menu is null",
                    Success = false
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

        /// <summary>
        /// get menu children and menu action
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-menu-child/{MenuID}/{MenuType}")]
        public async Task<ResponseApi> GetMenuChildren(string MenuID, int MenuType)
        {
            // MenuType => 0 menu parrent, 1 = menu, 2 =  action
            try
            {
                if (!string.IsNullOrEmpty(MenuID))
                {
                    var findMenu = _AppDbContext.menus.AsTracking()
                        .Where(x => x.Parent.Equals(Guid.Parse(MenuID)) && x.MenuType.Equals(MenuType))
                        .ToList();

                    if (findMenu != null)
                    {
                        return new ResponseApi
                        {
                            Data = findMenu,
                            StatusCode = 0,
                            Message = "",
                            Success = true
                        };
                    }
                    return new ResponseApi
                    {
                        Data = null,
                        StatusCode = 0,
                        Message = "not find menu",
                        Success = false
                    };
                }
                return new ResponseApi
                {
                    Data = null,
                    StatusCode = 0,
                    Message = "menu is null",
                    Success = false
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
        //[ServiceFilter(typeof(BasicAuthenticationAttribute))]
        [Route("get-list-action/{MenuId}")]
        public async Task<ResponseApi> GetListAction(string MenuId)
        {
            try
            {
                if (string.IsNullOrEmpty(MenuId.Trim()))
                {
                    return new ResponseApi
                    {
                        Data = null,
                        StatusCode = 1,
                        Message = "MenuId is null",
                        Success = true
                    };
                }
                var checkedMenuAction = _AppDbContext.menus.FirstOrDefault(m => m.MenuId == Guid.Parse(MenuId.Trim()));
                if (checkedMenuAction == null)
                {
                    return new ResponseApi
                    {
                        Data = new List<ActionMenuModel>(),
                        StatusCode = 2,
                        Message = "Menu without action list",
                        Success = true
                    };
                }
                else
                {
                    if (checkedMenuAction.IsMenuAction == false)
                    {
                        return new ResponseApi
                        {
                            Data = null,
                            StatusCode = 3,
                            Message = "menu not is menu action",
                            Success = true
                        };
                    }
                    else
                    {
                        var listAction = _AppDbContext.actionMenus.Where(x => x.MenuId.ToString() == MenuId)
                                                .Select(m => new ActionMenuModel()
                                                {
                                                    Id = m.Id.ToString(),
                                                    ActionName = m.ActionName,
                                                    ActionCodeApi = m.ActionCodeApi,
                                                    IsActive = m.IsActive,
                                                    ActionTitle = m.ActionTitle,
                                                    PathName = m.PathName,
                                                    MenuId = m.MenuId.ToString(),
                                                    Status = m.Status,
                                                }).ToList();
                        return new ResponseApi
                        {
                            Data = listAction,
                            StatusCode = 4,
                            Message = "",
                            Success = true
                        };
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
        }

        [HttpPost]
        [Route("save-action-menu")]
        public async Task<ResponseApi> saveActionMenu(ActionMenuModel actionMenu)
        {
            try
            {
                var findMenu = _AppDbContext.menus.AsTracking().Where(x => x.MenuId.Equals(Guid.Parse(actionMenu.MenuId))).FirstOrDefault();
                if (findMenu.IsMenuAction == false)
                {
                    return new ResponseApi
                    {
                        Data = null,
                        StatusCode = 0,
                        Message = "Menu is not action menu",
                        Success = false
                    };
                }
                var action = new ActionMenu();
                switch (actionMenu.typeSave)
                {
                    //typeSave=1: Thêm mới
                    case 1:
                        action = new ActionMenu()
                        {
                            Id = Guid.NewGuid(),
                            ActionName = actionMenu.ActionName,
                            ActionCodeApi = actionMenu.ActionCodeApi,
                            IsActive = actionMenu.IsActive,
                            ActionTitle = actionMenu.ActionTitle,
                            PathName = actionMenu.PathName,
                            MenuId = Guid.Parse(actionMenu.MenuId),
                            Status = actionMenu.Status,
                        };
                        _AppDbContext.actionMenus.Add(action);
                        break;
                    //typeSave=2:chỉnh sửa
                    case 2:
                        action = _AppDbContext.actionMenus.FirstOrDefault(m => m.Id.ToString() == actionMenu.Id);
                        if (action is null)
                        {
                            return new ResponseApi
                            {
                                Data = null,
                                StatusCode = 0,
                                Message = "action is null",
                                Success = false
                            };
                        }
                        action.ActionTitle = actionMenu.ActionTitle;
                        action.PathName = actionMenu.PathName;
                        action.ActionName = actionMenu.ActionName;
                        action.ActionCodeApi = actionMenu.ActionCodeApi;
                        action.IsActive = actionMenu.IsActive;
                        action.Status = actionMenu.Status;
                        _AppDbContext.actionMenus.Update(action);
                        break;
                    default:
                        break;
                }
                _AppDbContext.SaveChanges();
                return new ResponseApi
                {
                    Data = 1,
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
                    StatusCode = 0,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
        [HttpPost]
        [Route("delete-action-menu/{actionId}")]
        public async Task<ResponseApi> deleteActionMenu(string actionId)
        {
            try
            {
                var action = _AppDbContext.actionMenus.FirstOrDefault(m => m.Id.ToString() == actionId);
                if (action is null)
                {
                    return new ResponseApi
                    {
                        Data = null,
                        StatusCode = 0,
                        Message = "action is null",
                        Success = false
                    };
                }
                _AppDbContext.actionMenus.Remove(action);
                _AppDbContext.SaveChanges();
                return new ResponseApi
                {
                    Data = 1,
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
                    StatusCode = 0,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
        [HttpPost]
        [Route("save-permission-menu/{PermissionsId}")]
        public async Task<ResponseApi> savePermissionMenu(string PermissionsId, List<listPermissionMenu> request)
        {
            try
            {
                var sqlDelete = @"DELETE FROM permissionMenus WHERE PermissionsId= @PermissionsId";
                var Parameter = new SqlParameter("PermissionsId", PermissionsId);
                if (request == null || request.Count == 0)
                {
                    _AppDbContext.Database.ExecuteSqlRaw(sqlDelete, Parameter);
                    return new ResponseApi
                    {
                        Data = 1,
                        StatusCode = 0,
                        Message = "Success",
                        Success = true,
                    };

                }

                var permission = _AppDbContext.permissions.FirstOrDefault(m => m.PermissionsId == Guid.Parse(PermissionsId));
                if (permission is null)
                {
                    return new ResponseApi
                    {
                        Data = null,
                        StatusCode = 4,
                        Message = "PermissionsId is null",
                        Success = true,
                    };
                }
                _AppDbContext.Database.ExecuteSqlRaw(sqlDelete, Parameter);
                var listSave = new List<PermissionMenu>();
                request.ForEach(item =>
                {
                    listSave.Add(new PermissionMenu()
                    {
                        Id = item.Id,
                        ActionMenuId = item.ActionMenuId,
                        MenuId = item.MenuId,
                        PermissionsId = item.PermissionsId,
                    });
                });

                if (listSave.Count > 0)
                {
                    _AppDbContext.permissionMenus.AddRange(listSave);
                    _AppDbContext.SaveChanges();
                }

                return new ResponseApi
                {
                    Data = 1,
                    StatusCode = 0,
                    Message = "Success",
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
        [Route("get-all-menu-and-action/{PermissionsId}")]
        public async Task<ResponseApi> getAllMenuAction(string PermissionsId)
        {
            try
            {
                var arrMenu = _AppDbContext.menus.OrderBy(x => x.sortOrder).Select(m => new MenuAction()
                {
                    label = m.MenuName,
                    value = m.MenuId.ToString(),
                    parent = m.Parent != null ? m.Parent.ToString() : "",
                    level = m.Islevel,
                }).ToList();
                var arrAction = _AppDbContext.actionMenus.Select(m => new MenuAction()
                {
                    label = m.ActionName,
                    value = m.Id.ToString(),
                    parent = m.MenuId.ToString(),
                    level = 100,
                }).ToList();

                arrMenu.AddRange(arrAction);

                // lay id danh sach menu issaction = true voi dieu kien dc phan quyen trong permissionMenus
                var MenuActions = _AppDbContext.permissionMenus.Where(m => m.PermissionsId == Guid.Parse(PermissionsId)).Select(x => x.ActionMenuId.ToString()).ToList();

                var Parameter = new SqlParameter("PermissionsId", PermissionsId);
                var sql = @"WITH #results
                            AS (SELECT  MenuId,
                                        MenuName,
					                    MenuTitle,
					                    MenuType,
					                    Parent,
					                    ActionApi,
					                    ActionCode,
					                    Status,
					                    IsMenuAction,
					                    IsHorizontal,
                                        Islevel,
                                        IsDefault,
										comPath,
										path,
                                        imagePath,
                                        sortOrder
                                FROM dbo.menus
                                WHERE MenuId IN (select DISTINCT MenuId from permissionMenus WHERE PermissionsId = @PermissionsId) 
                                UNION ALL
                                SELECT  t.MenuId,
                                        t.MenuName,
					                    t.MenuTitle,
					                    t.MenuType,
					                    t.Parent,
					                    t.ActionApi,
					                    t.ActionCode,
					                    t.Status,
					                    t.IsMenuAction,
					                    t.IsHorizontal,
                                        t.Islevel,
                                        t.IsDefault,
										t.comPath,
										t.path,
                                        t.imagePath,
                                        t.sortOrder
                                FROM dbo.menus t
                                    INNER JOIN #results r
                                        ON r.Parent = t.MenuId
                            )
                            SELECT      MenuId,
                                        MenuName,
					                    MenuTitle,
					                    MenuType,
					                    Parent,
					                    ActionApi,
					                    ActionCode,
					                    Status,
					                    IsMenuAction,
					                    IsHorizontal,
                                        Islevel,
                                        IsDefault,
										comPath,
										path,
                                        imagePath,
                                        sortOrder
                            FROM #results GROUP BY  
                                        MenuId,
                                        MenuName,
					                    MenuTitle,
					                    MenuType,
					                    Parent,
					                    ActionApi,
					                    ActionCode,
					                    Status,
					                    IsMenuAction,
					                    IsHorizontal,
                                        Islevel,
                                        IsDefault,
										comPath,
										path,
                                        imagePath,
                                        sortOrder";

                var getmenuparent = _AppDbContext.menus.FromSqlRaw(sql, Parameter).ToList();

                var MenuIdChecked = getmenuparent.Select(x => x.MenuId.ToString()).ToList();
                MenuIdChecked.AddRange(MenuActions);
                return new ResponseApi
                {
                    Data = new GetAllMenuResponse()
                    {
                        MenuActions = arrMenu,
                        Checked = MenuIdChecked
                    },
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
        [Route("get-tree-menu-by-userid/{userId}")]
        public async Task<ResponseApi> getTreeMenuFE(string userId)
        {
            try
            {
                var Parameter = new SqlParameter("UserId", userId);
                var sql = @"WITH #results
									AS (SELECT  MenuId,
										MenuName,
					                    MenuTitle,
					                    MenuType,
					                    Parent,
					                    ActionApi,
					                    ActionCode,
					                    Status,
					                    IsMenuAction,
					                    IsHorizontal,
                                        Islevel,
										IsDefault,
										comPath,
										path,
                                        imagePath,
                                        sortOrder
                                FROM dbo.menus
                                WHERE MenuId IN (select DISTINCT MenuId from permissionMenus WHERE PermissionsId IN (SELECT PermissionsId FROM userPermissions WHERE UserId=@UserId)) 
                                UNION ALL
                                SELECT  t.MenuId,
                                        t.MenuName,
					                    t.MenuTitle,
					                    t.MenuType,
					                    t.Parent,
					                    t.ActionApi,
					                    t.ActionCode,
					                    t.Status,
					                    t.IsMenuAction,
					                    t.IsHorizontal,
                                        t.Islevel,
										t.IsDefault,
										t.comPath,
										t.path,
                                        t.imagePath,
                                        t.sortOrder
                                FROM dbo.menus t
                                    INNER JOIN #results r
                                        ON r.Parent = t.MenuId
                            )
                            SELECT      MenuId,
                                        MenuName,
					                    MenuTitle,
					                    MenuType,
					                    Parent,
					                    ActionApi,
					                    ActionCode,
					                    Status,
					                    IsMenuAction,
					                    IsHorizontal,
                                        Islevel,
										IsDefault,
										comPath,
										path,
                                        imagePath,
                                        sortOrder
                            FROM #results GROUP BY  
                                        MenuId,
                                        MenuName,
					                    MenuTitle,
					                    MenuType,
					                    Parent,
					                    ActionApi,
					                    ActionCode,
					                    Status,
					                    IsMenuAction,
					                    IsHorizontal,
                                        Islevel,
										IsDefault,
										comPath,
										path,
                                        imagePath,
                                        sortOrder;";

                var getmenuparent = _AppDbContext.menus.FromSqlRaw(sql, Parameter).ToList();

                var menustring = "";
                if (getmenuparent != null && getmenuparent.Count > 0)
                {
                    var listmenuaction = getmenuparent.FindAll(x => x.IsMenuAction == true).Select(x => x.MenuId.ToString());
                    menustring = String.Join(",", listmenuaction);
                }
                var listActionMenu = new List<ActionMenu>();
                if (!string.IsNullOrEmpty(menustring))
                {
                    var ParameterActionMenu = new SqlParameter("stringmenu", menustring);
                    var sqlGetAction = @"SELECT Id,MenuId,ActionName,ActionTitle,PathName,ActionCodeApi,IsActive,Status from actionMenus WHERE MenuId in (@stringmenu)";
                    listActionMenu = _AppDbContext.actionMenus.FromSqlRaw(sqlGetAction, ParameterActionMenu).ToList();
                }

                // khi lay menus xong va tiep tuc lay actionMenus => giua menu va actionMenus co quan he 1=>n nen EF tu dong lazy load theo mo hinh thuc the => tu dong map actionmenu vao menu

                return new ResponseApi
                {
                    Data = new TreeSlideBar()
                    {
                        listMenu = getmenuparent.OrderBy(x => x.sortOrder).ToList(),
                        listActionMenu = listActionMenu
                    },
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
    }
}
