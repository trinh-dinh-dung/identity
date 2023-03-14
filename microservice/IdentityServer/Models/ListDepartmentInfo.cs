using System;
using System.Collections.Generic;

namespace IdentityServer.Models
{
    public class ListDepartmentInfo
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int status { get; set; }
        public List<UserMapResponse> appUsers { get; set; }
    }
}
