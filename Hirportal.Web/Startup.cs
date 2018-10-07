using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hirportal.Data;
using Hirportal.Models;
using Hirportal.Services;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Bll.Services;
using AutoMapper;
using Hirportal.Bll;

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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            var assembly = typeof(IEmailSender).Assembly;
            var serviceTypes = assembly.ExportedTypes
               .Where(e => e.IsClass && e.IsPublic && !e.IsAbstract)
               .Where(e => e.Namespace == "Hirportal.Bll.Services")
               .ToList();

            foreach (var serviceType in serviceTypes)
            {
                services.AddTransient(serviceType.GetInterface($"I{serviceType.Name}"), serviceType);
            }

            services.AddAutoMapper();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            AutoMapperConfiguration.Configure();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
