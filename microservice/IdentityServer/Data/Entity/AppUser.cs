using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Entity
{
    public class AppUser : IdentityUser
    {
        public bool IsAdministrator { get; set; }
        public bool IsAdmin { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(250)]
        public string FullName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        //public string UserSystemCode { get; set; }

        public Guid DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department department { get; set; }

        public Guid JobTitleId { get; set; }

        [ForeignKey("JobTitleId")]
        public JobTitle jobTitle { get; set; }
        public List<UserPermission> userPermissions { get; set; }


    }


    public class PagingUser
    {
        public PagingUser()
        {
            listData = new List<AppUser>();
        }

        public int PAGE_NUMBER { get; set; }
        public int PAGE_SIZE { get; set; }
        public int TOTAL_RECORD { get; set; }
        public int STATUS { get; set; }
        public string KEY { get; set; }
        public List<AppUser> listData { get; set; }
    }
}
