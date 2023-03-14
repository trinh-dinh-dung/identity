using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Entity
{
    public class UserPermission
    {
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser appUser { get; set; }
        public Guid PermissionsId { get; set; }
        [ForeignKey("PermissionsId")]
        public Permissions permissions { get; set; }

    }
}
