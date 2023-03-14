using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Data.Entity
{
    public class JobTitle
    {
        [Key]
        public Guid JobTitleId { get; set; }
        public string JobTitleName { get; set; }
        public int status { get; set; }
        public List<AppUser> appUsers { get; set; }

    }
}
