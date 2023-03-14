using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models
{
    public class ApplicationUser: IdentityUser
    {
        public bool IsAdmin { get; set; }
        public string Address { get; set; }
    }
}
