using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core22MVCIdentity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core22MVCIdentity.Models;
using Microsoft.AspNetCore.Routing;

namespace Core22MVCIdentity
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
            services.AddResponseCaching();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<ApplicationDbContext>(opt =>
            //opt.UseNpgsql("TenMinutes"));

            services.AddEntityFrameworkNpgsql().
                AddDbContext<ApplicationDbContext>(opt => 
                opt.UseNpgsql(Configuration.GetConnectionString("DbConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseNpgsql("Server=localhost;Port=5432;Database=Test;User ID=postgres;Password=123456;"));

            services.AddDefaultIdentity<ApplicationUsers>()
                //.AddRoles<UserRoles>()
                //.AddRoleManager<RoleManager<UserRoles>>()
              
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");
            app.UseResponseCaching();
            //app.Use(async (context, next) =>
            //{
            //    context.Response.GetTypedHeaders().CacheControl =
            //        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
            //        {
            //            Public = true,
            //            MaxAge = TimeSpan.FromSeconds(10)
            //        };
            //    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
            //        new string[] { "Accept-Encoding" };

            //    await next();
            //});
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {

                //routes.MapRoute("CL", "{SName}/{CName}/{CId}", new { controller = "Home", action = "XYZ2" });
                //routes.MapRoute("HRDetail", "H-R/{TName}/{MId}", new { controller = "Home", action = "XYZ1" });
                routes.MapRoute(
                        name: "areas",
                        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                      );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseMvc(routes =>
            {
                
                routes.MapGet("{*path}", (RequestDelegate)(ctx =>
                {
                    var defaultCulture = "en";
                    var path = ctx.GetRouteValue("path") ?? string.Empty;
                    path = path.ToString().Contains("en/") ? path.ToString().Replace("en/", "") : path;

                    var culturedPath = $"/{defaultCulture}/{path}";
                    ctx.Response.Redirect(culturedPath);
                    ctx.Response.WriteAsync("hello " +  culturedPath);
                    return Task.CompletedTask;
                }));

                routes.MapRoute(
                    name: "defaultculture",
                    template: "{culture=culturecode}/{controller=Home}/{action=Index}/{id?}");
                //routes.MapGet("{culture=culturecode}/{*path}", appBuilder => { return null; });

            });

        }
    }
}
