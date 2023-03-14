using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Entity
{
    public class Menu
    {
        [Key]
        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuTitle { get; set; }
        public int MenuType { get; set; }
        public Guid? Parent { get; set; }
        public int ActionApi { get; set; }
        public string ActionCode { get; set; }
        public int Status { get; set; }
        public bool IsMenuAction { get; set; }
        public bool IsHorizontal { get; set; }
        public int Islevel { get; set; }
        public bool? IsDefault { get; set; }
        public string comPath { get; set; }
        public string path { get; set; }
        public string imagePath { get; set; }
        public int? sortOrder { get; set; }
        public List<PermissionMenu> permissionMenus { get; set; }
        public List<ActionMenu> actionMenus { get; set; }
    }
}
