using System;

namespace IdentityServer.Models
{
    public class UserMapResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Guid JobTitleId { get; set; }
        public string JobTitleName { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }


    public class UserMapResponseJobTitle
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Guid JobTitleId { get; set; }
        public string JobTitleName { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
}
