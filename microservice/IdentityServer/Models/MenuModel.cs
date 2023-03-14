using IdentityServer.Data.Entity;
using System;
using System.Collections.Generic;

namespace IdentityServer.Models
{
    public class MenuModel
    {
        public MenuModel()
        {
            ActionMenu = new List<ActionMenuModel>();
        }
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuTitle { get; set; }
        public int MenuType { get; set; }
        public string Parent { get; set; }
        public int ActionApi { get; set; }
        public string ActionCode { get; set; }
        public int Status { get; set; }
        public bool IsMenuAction { get; set; }
        public bool IsHorizontal { get; set; }
        public int EntityStatus { get; set; }
        public int Islevel { get; set; }
        public bool? IsDefault { get; set; }
        public string comPath { get; set; }
        public string path { get; set; }
        public string imagePath { get; set; }
        public int? sortOrder { get; set; }

        public List<ActionMenuModel> ActionMenu { get; set; }

    }

    public class ActionMenuModel
    {
        public int typeSave { get; set; }
        public string Id { get; set; }
        public string ActionName { get; set; }
        public string ActionTitle { get; set; }
        public string PathName { get; set; }
        public string ActionCodeApi { get; set; }
        public bool IsActive { get; set; }
        public int Status { get; set; }
        public string MenuId { get; set; }

    }
    public class TreeSlideBar
    {
        public TreeSlideBar()
        {
            listMenu = new List<Menu>();
            listActionMenu = new List<ActionMenu>();
        }

        public List<Menu> listMenu { get; set; }
        public List<ActionMenu> listActionMenu { get; set; }
    }
    public class listPermissionMenu
    {
        public Guid Id { get; set; }
        public Guid ActionMenuId { get; set; }
        public Guid MenuId { get; set; }
        public Guid PermissionsId { get; set; }
    }
    //public class PermissionRequest
    //{
    //    public int typeSave { get; set; }
    //    public string PermissionsId { get; set; }
    //    public List<listPermissionMenu> listPermissionAction { get; set; }
    //}

    public class GetAllMenuResponse
    {
        public GetAllMenuResponse()
        {
            MenuActions = new List<MenuAction>();
            Checked = new List<string>();
        }
        public List<MenuAction> MenuActions { get; set; }
        public List<string> Checked { get; set; }
    }

    public class MenuAction
    {
        public string value { get; set; }
        public string label { get; set; }
        public string parent { get; set; }
        public int level { get; set; }
    }
    public class PagingMenu
    {
        public PagingMenu()
        {
            listData = new List<MenuModel>();
        }

        public int PAGE_NUMBER { get; set; }
        public int PAGE_SIZE { get; set; }
        public int TOTAL_RECORD { get; set; }
        public int STATUS { get; set; }
        public string KEY { get; set; }
        public string Parent { get; set; }
        public List<MenuModel> listData { get; set; }
    }
}
