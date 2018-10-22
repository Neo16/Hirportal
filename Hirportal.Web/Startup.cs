using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hirportal.Bll.ServiceInterfaces;
using AutoMapper;
using Hirportal.Bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hirportal.Model;
using Hirportal.Bll.Services;
using Hirportal.Dal;

namespace Hirportal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            var assembly = typeof(IEmailSender).Assembly;
            var serviceTypes = assembly.ExportedTypes
               .Where(e => e.IsClass && e.IsPublic && !e.IsAbstract)
               .Where(e => e.IsSubclassOf(typeof(ServiceBase)))
               .ToList();

            foreach (var serviceType in serviceTypes)
            {
                services.AddTransient(serviceType.GetInterface($"I{serviceType.Name}"), serviceType);
            }

            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();          
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            AutoMapperConfiguration.Configure();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "api",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                  name: "default",
                  template: "{*url}",
                  defaults: new { controller = "Home", action = "Index" });
            });

            context.Seed();
        }
    }
}
