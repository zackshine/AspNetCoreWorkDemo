using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Core3MVC.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Core3MVC.Filters;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Http;
using Core3MVC.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

namespace Core3MVC
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

                //options.CheckConsentNeeded = context => false;
                //options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(Options =>
            {
                Options.Cookie.Name = ".MySessionName";
                Options.IdleTimeout = TimeSpan.FromMinutes(10);
                Options.Cookie.IsEssential = true;
            });

            var connectionString = new ConnectionString(Configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString.Value));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();



            services.AddControllersWithViews(
            //options =>

            //    options.Filters.Add(new AuthorizeMultiplePolicyFilter(new string[] { "UserIsAuthenticated" }))

            ).AddNewtonsoftJson(options =>
            {
                // options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });


            services.AddRazorPages();

            services.AddAuthorization(options =>
            {

                options.AddPolicy("UserIsAuthenticated", policy =>
                    policy.RequireAuthenticatedUser());
                options.AddPolicy("UserIsRegistered", policy =>
                     policy.Requirements.Add(new CheckADGroupRequirement("DOMAIN\\Domain Admin")));
                options.AddPolicy("ADRoleOnly", policy =>
                    policy.Requirements.Add(new CheckADGroupRequirement("DOMAIN\\Domain Admin")));
            });
            //services.AddSingleton<IAuthorizationHandler, CheckADGroupHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRole", policy =>
                    policy.Requirements.Add(new CheckUserRoleRequirement("Admin")));
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationHandler, CheckUserRoleHandler>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            Action<GlobalData> gData = (g =>
            {
                g.CompanyCode = 2;
                g.DummyCust = 3;
                g.Type_Personal = 0;
                g.Type_Asset = 1;
                g.Type_Bank = 2;

                g.Type_Customer = 1;
                g.Type_Staff = 2;

            });
            services.Configure(gData);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<GlobalData>>().Value);
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Dictionary<string, string> connStrs = new Dictionary<string, string>();
            connStrs.Add("DB1", Configuration.GetConnectionString("DefaultConnection"));
            connStrs.Add("DB2", Configuration["ConnectionStrings:AnotherConnection"]);
            DbContextFactory.SetConnectionString(connStrs);
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
            //app.UseRewriter(new RewriteOptions()
            //    .Add(StaticFileRewriteRules.RedirectRequests)
            //   .Add(StaticFileRewriteRules.ReWriteRequests)
            //   );
            ////或者下面的规则，去html显示静态页面
            //app.UseRewriter(new RewriteOptions()
            //    .AddRedirect("DemoSignUp.html", "DemoSignUp")
            //    .AddRewrite("DemoSignUp", "DemoSignUp.html", skipRemainingRules: false));

            app.UseStaticFiles();
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new
                 PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),
                 "Areas\\Dashboard\\Content")),
                RequestPath = new PathString("/Dashboard/Content")
            });
            app.UseSession();
            app.UseCookiePolicy();


            //app.UseRewriter(new RewriteOptions().AddRedirect("(.*[^/])$", "$1/"));
            //app.UseRewriter(new RewriteOptions().Add(new RewriteRuleTest()));
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.Use(async (context, next) =>
            //{

            //    string url = context.Request.Headers["HOST"];
            //    var splittedUrl = url.Split('.');

            //    if (splittedUrl != null && (splittedUrl.Length > 0 && splittedUrl[0] == "admin"))
            //    {
            //        context.GetRouteData().Values.Add("area", "Admin");
            //    }

            //    // Call the next delegate/middleware in the pipeline
            //    await next();
            //});
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapAreaControllerRoute(
                //    name: "Dashboard",
                //    areaName: "Dashboard",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                //);
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"

                    );
                //endpoints.MapAreaControllerRoute(
                //    name: "Main",
                //    areaName: "Main",
                //    pattern: "{controller=Home}/{action=Index}/{id?}"
                //);
                endpoints.MapRazorPages();
            });
        }
    }
}
