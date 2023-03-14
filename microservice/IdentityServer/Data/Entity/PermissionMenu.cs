using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Entity
{
    public class PermissionMenu
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ActionMenuId { get; set; }
        [ForeignKey("ActionMenuId")]
        public ActionMenu actionMenu { get; set; }

        public Guid MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu menu { get; set; }

        public Guid PermissionsId { get; set; }
        [ForeignKey("PermissionsId")]
        public Permissions permissions { get; set; }

    }
}
