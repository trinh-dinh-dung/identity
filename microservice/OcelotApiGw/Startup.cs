using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;



namespace OcelotApiGw
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();

                builder.WithOrigins(
                    "http://localhost:3000",
                    "https://localhost:3000",
                    "http://192.168.2.103:8099",
                    "https://192.168.2.103:8099",
                    "http://192.168.2.103:8020",
                    "https://192.168.2.103:8020"
                    )
                  .AllowAnyMethod()
                  .AllowAnyHeader();
            }));

            var authenticationProviderKey = "IdentityApiKey";

            // NUGET - Microsoft.AspNetCore.Authentication.JwtBearer
            services.AddAuthentication().AddJwtBearer(authenticationProviderKey, x =>
             {
                 x.Authority = "https://authen.viecgicungco.com"; // IDENTITY SERVER URL
                 //x.RequireHttpsMetadata = false;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = false
                 };
             });
            //services.AddOcelot();
            services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            await app.UseOcelot();
        }
    }
}
