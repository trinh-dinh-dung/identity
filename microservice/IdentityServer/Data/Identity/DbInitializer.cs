using IdentityServer.Data.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data.Identity
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(AppDbContext context, UserManager<AppUser> UserManager)
        {
            try
            {

                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //InserData(context);

                //await CreateUserAsync(context, UserManager);

                //if (context.Users.Any())
                //    {
                //        return;   // DB has been seeded
                //    }
                //var user = await UserManager.FindByNameAsync("admin@gmail.com");
                //if (user == null)
                //{
                //    var model = new AppUser();
                //    model.UserName = "admin@gmail.com";
                //    model.Email = "admin@gmail.com";
                //    model.PhoneNumber = "0393977608";
                //    model.EmailConfirmed = true;
                //    model.IsAdministrator = true;
                //    model.IsAdmin = true;
                //    model.FullName = "Admin system ";
                //    model.Address = "Hà Nội";
                //    var result = await UserManager.CreateAsync(model, "!@#");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //throw ex;
            }

        }

        static async Task CreateUserAsync(AppDbContext dbcontext, UserManager<AppUser> UserManager)
        {

            var user = await UserManager.FindByNameAsync("admin@gmail.com");
            if (user == null)
            {
                var model = new AppUser();
                model.UserName = "admin@gmail.com";
                model.Email = "admin@gmail.com";
                model.PhoneNumber = "0393977608";
                model.EmailConfirmed = true;
                model.IsAdministrator = true;
                model.IsAdmin = true;
                model.FullName = "Admin system ";
                model.Address = "Hà Nội";
                model.JobTitleId = Guid.Parse("a83a70d4-e4de-4d9c-a9c4-6b82fa49f977");
                model.DepartmentId = Guid.Parse("ccfb0dc7-7ed3-4998-a8d5-5346f8dd7e12");
                var result = await UserManager.CreateAsync(model, "!@#");
            }


            var user1 = await UserManager.FindByNameAsync("ketoan@gmail.com");
            if (user1 == null)
            {
                var model = new AppUser();
                model.UserName = "ketoan@gmail.com";
                model.Email = "ketoan@gmail.com";
                model.PhoneNumber = "0393977608";
                model.EmailConfirmed = true;
                model.IsAdministrator = true;
                model.IsAdmin = true;
                model.FullName = "ketoan system ";
                model.Address = "Hà Nội";
                model.JobTitleId = Guid.Parse("a83a70d4-e4de-4d9c-a9c4-6b82fa49f977");
                model.DepartmentId = Guid.Parse("87d9fd36-ca46-4dfb-9c67-9435c73f80a4");
                var result = await UserManager.CreateAsync(model, "!@#");
            }

            var user2 = await UserManager.FindByNameAsync("taichinh@gmail.com");
            if (user2 == null)
            {
                var model = new AppUser();
                model.UserName = "taichinh@gmail.com";
                model.Email = "taichinh@gmail.com";
                model.PhoneNumber = "0393977608";
                model.EmailConfirmed = true;
                model.IsAdministrator = true;
                model.IsAdmin = true;
                model.FullName = "taichinh system ";
                model.Address = "Hà Nội";
                model.JobTitleId = Guid.Parse("a83a70d4-e4de-4d9c-a9c4-6b82fa49f977");
                model.DepartmentId = Guid.Parse("ccfb0dc7-7ed3-4998-a8d5-5346f8dd7e12");
                var result = await UserManager.CreateAsync(model, "!@#");
            }

            var user3 = await UserManager.FindByNameAsync("dieuphoi@gmail.com");
            if (user3 == null)
            {
                var model = new AppUser();
                model.UserName = "dieuphoi@gmail.com";
                model.Email = "dieuphoi@gmail.com";
                model.PhoneNumber = "0393977608";
                model.EmailConfirmed = true;
                model.IsAdministrator = true;
                model.IsAdmin = true;
                model.FullName = "dieuphoi system ";
                model.Address = "Hà Nội";
                model.JobTitleId = Guid.Parse("a83a70d4-e4de-4d9c-a9c4-6b82fa49f977");
                model.DepartmentId = Guid.Parse("93b0e5c0-88eb-480e-b43b-9d2d1c1924b1");
                var result = await UserManager.CreateAsync(model, "!@#");
            }
        }

        static void InserData(AppDbContext dbcontext)
        {

            var d1 = new Department()
            {
                DepartmentId = Guid.Parse("87d9fd36-ca46-4dfb-9c67-9435c73f80a4"),
                DepartmentName = "Phòng Kế Toán",
                status = 1
            };
            var d2 = new Department()
            {
                DepartmentId = Guid.Parse("ccfb0dc7-7ed3-4998-a8d5-5346f8dd7e12"),
                DepartmentName = "Phòng Tài Chính",
                status = 1
            };
            var d3 = new Department()
            {
                DepartmentId = Guid.Parse("93b0e5c0-88eb-480e-b43b-9d2d1c1924b1"),
                DepartmentName = "Phòng Điều Phối",
                status = 1
            };
            dbcontext.departments.Add(d1);
            dbcontext.departments.Add(d2);
            dbcontext.departments.Add(d3);

            var j1 = new JobTitle()
            {
                JobTitleId = Guid.Parse("a83a70d4-e4de-4d9c-a9c4-6b82fa49f977"),
                JobTitleName = "Trưởng phòng",
                status = 1
            };

            var j2 = new JobTitle()
            {
                JobTitleId = Guid.Parse("52b38684-79a3-4bcc-96b5-5b31291c827b"),
                JobTitleName = "Phó phòng",
                status = 1
            };
            var j3 = new JobTitle()
            {
                JobTitleId = Guid.Parse("e9688842-e216-4132-9b97-461233944204"),
                JobTitleName = "Nhân viên",
                status = 1
            };

            dbcontext.jobTitles.Add(j1);
            dbcontext.jobTitles.Add(j2);
            dbcontext.jobTitles.Add(j3);


            dbcontext.SaveChanges();

        }


    }
}
