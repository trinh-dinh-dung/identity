using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Data.Entity
{
    public class Permissions
    {

        [Key]
        public Guid PermissionsId { get; set; }
        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }
        public int Status { get; set; }

        public List<UserPermission> userPermissions { get; set; }
        public List<PermissionMenu> permissionMenus { get; set; }

    }
}
