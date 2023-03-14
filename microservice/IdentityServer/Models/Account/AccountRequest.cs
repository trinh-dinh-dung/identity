using System;

namespace IdentityServer.Models.Account
{
    public class CreateAccountRequest
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Code { get; set; }

        public bool? Status { get; set; }

        public int? Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool? Isquitwork { get; set; }

        public bool? Isallowlogin { get; set; }
        public string Password { get; set; }
    }
}
