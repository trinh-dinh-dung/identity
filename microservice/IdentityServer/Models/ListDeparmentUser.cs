using System;
using System.Collections.Generic;

namespace IdentityServer.Models
{
    public class ListDeparmentUser
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Status { get; set; }
        public List<UserMapResponse> appUsers { get; set; }

    }
}
