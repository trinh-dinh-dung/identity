using IdentityServer.Data.Identity;

namespace IdentityServer.Security
{
    public class VerifyProfile
    {
        private readonly AppDbContext _dbContext;

        public VerifyProfile(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
