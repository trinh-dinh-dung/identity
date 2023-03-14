using IdentityServer.Data.Entity;
using System;
using System.Collections.Generic;

namespace IdentityServer.Models
{
    public class Permission
    {
        public string PermissionsId { get; set; }
        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }
        public int Status { get; set; }
    }
    public class DataUserPermission
    {
        public List<Permissions> listPermissions { get; set; }
        public List<string> listPerByUser { get; set; }
    }
    public class PagingPermission
    {
        public PagingPermission()
        {
            listData = new List<Permission>();
        }

        public int PAGE_NUMBER { get; set; }
        public int PAGE_SIZE { get; set; }
        public int TOTAL_RECORD { get; set; }
        public int STATUS { get; set; }
        public string KEY { get; set; }
        public List<Permission> listData { get; set; }
    }

    public class linkPermissionUser
    {
        public string userId { get; set; }
        public List<string> listPermissions { get; set; }
    }
    public class PermissionAddModal
    {
        public Guid PermissionsId { get; set; }
        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }
        public int Status { get; set; }
    }

}
