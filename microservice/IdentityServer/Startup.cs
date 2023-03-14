// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;
using IdentityServer.Data.Identity;
using Microsoft.AspNetCore.Identity;
using IdentityServer.Data.Entity;
using System;
using IdentityServer.Security;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using IdentityServer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<VerifyProfile>();
            services.AddScoped<BasicAuthenticationAttribute>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            var configSettings = Configuration.GetSection("Appsettings").Get<Appsettings>();
            services.Configure<Appsettings>(Configuration.GetSection("Appsettings"));

            //services.AddControllersWithViews().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //});


            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            }).AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);


            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configSettings.DefaultConnection));

            //services.AddIdentity<AppUser, IdentityRole>()
            //.AddEntityFrameworkStores<AppDbContext>()
            //.AddDefaultTokenProviders();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();



            services.AddIdentityServer(options =>
            {
                //options.Events.RaiseErrorEvents = true;
                //options.Events.RaiseInformationEvents = true;
                //options.Events.RaiseFailureEvents = true;
                //options.Events.RaiseSuccessEvents = true;
                //// see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                //options.EmitStaticAudienceClaim = false;
                options.Authentication.CookieSameSiteMode = SameSiteMode.Lax;

                options.Authentication.CookieLifetime = TimeSpan.FromDays(30);
                options.Authentication.CookieSlidingExpiration = true;


            })
             .AddInMemoryClients(Config.Clients)
             .AddInMemoryApiScopes(Config.ApiScopes)
             .AddInMemoryIdentityResources(Config.IdentityResources)
             //.AddTestUsers(TestUsers.Users)
             .AddDeveloperSigningCredential()
             .AddAspNetIdentity<AppUser>()
             ;

            // config identity passs
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;


            });

            //string connectstring = Configuration.GetConnectionString("AppDbContext");
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    // Đọc chuỗi kết nối
            //    // Sử dụng MS SQL Server
            //    options.UseSqlServer(connectstring);
            //});
            //services.AddIdentityServer()
            //    .AddTestUsers(TestUsers.Users)
            //    .AddConfigurationStore(options =>
            //    {
            //        options.ConfigureDbContext = b => b.UseSqlServer(connectstring,
            //            sql => sql.MigrationsAssembly(migrationsAssembly));
            //    })
            //    .AddOperationalStore(options =>
            //    {
            //        options.ConfigureDbContext = b => b.UseSqlServer(connectstring,
            //            sql => sql.MigrationsAssembly(migrationsAssembly));
            //    });

        }

        public void Configure(IApplicationBuilder app)
        {
            CreateDbIfNotExists(app);
            //InitializeDatabase(app);
            if (Environment.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();
            app.UseCors("MyPolicy");
            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private static async void CreateDbIfNotExists(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    var UserManager = services.GetService<UserManager<AppUser>>();
                    await DbInitializer.InitializeAsync(context, UserManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
