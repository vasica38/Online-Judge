using System;
using System.Text;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Infrastructure.Identity;
using Core.Interfaces;
using Core;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication6.Startup))]
namespace WebApplication6
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        /*     private IServiceCollection _services;
             public IConfiguration Configuration { get; }

             public Startup(IConfiguration configuration)
             {
                 Configuration = configuration;
             }


             public void ConfigureDevelopmentServices(IServiceCollection services)
             {
                 // use in-memory database
                 ConfigureTestingServices(services);

                 // use real database
                 // ConfigureProductionServices(services)
             }

             private void ConfigureTestingServices(IServiceCollection services)
             {
                 services.AddDbContext<JudgeContext>(c =>
                     c.UseInMemoryDatabase("Catalog"));

                 services.AddDbContext<AppIdentityDbContext>(options =>
                 options.UseInMemoryDatabase("Identity"));

                 ConfigureServices(services);
             }

             public void ConfigureServices(IServiceCollection services)
             {
                 services.AddIdentity<ApplicationUser, IdentityRole>()
                     .AddEntityFrameworkStores<AppIdentityDbContext>()
                     .AddDefaultTokenProviders();

                 services.ConfigureApplicationCookie(options =>
                 {
                     options.Cookie.HttpOnly = true;
                     options.ExpireTimeSpan = TimeSpan.FromHours(1);
                     options.LoginPath = "/Account/Signin";
                     options.LogoutPath = "/Account/Signout";
                 });

                 services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
                 services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
                 services.AddScoped<GeneralDashboard>();
                 services.AddScoped<UserDashboard>();



                 throw new NotImplementedException();
             }
             */
    }
}
