using IdentityServer.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.Account.PermissionBusiness
{
    public class TestAccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public TestAccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("~/api/TestAccount/create-account-admin")]
        public async Task<IActionResult> CreateAccountAdmin()
        {
            var model = new AppUser();
            model.UserName = "admin@gmail.com";
            model.Email = "admin@gmail.com";
            model.PhoneNumber = "0837911078";
            model.EmailConfirmed = true;
            model.IsAdmin = true;
            model.Address = "123454";
            var result = await _userManager.CreateAsync(model, "123456789");
            return Ok(1);
        }

        [HttpPost]
        [Route("~/api/TestAccount/get-list-account")]
        public async Task<IActionResult> GetListAccountPagding(PagingUser paging)
        {
            var IsAuthentication = User.Identity.IsAuthenticated;
            //var IsAdmin = User.Identity;

            //var listUserPage = _userManager.Users.Skip(1).Take(1).ToList();
            var listUserPage = _userManager.Users.Skip(paging.PAGE_NUMBER * paging.PAGE_SIZE).Take(paging.PAGE_SIZE).ToList();

            return Ok(1);
        }
    }
}
