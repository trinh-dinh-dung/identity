using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace IdentityServer.Data.Entity
{
    public class Department
    {
        [Key]        
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int status { get; set; }
        public List<AppUser> appUsers { get; set; }

    }
}
