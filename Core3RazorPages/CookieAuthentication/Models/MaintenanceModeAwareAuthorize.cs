using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieAuthentication.Models
{
    public class MaintenanceModeAwareAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var data = context.HttpContext.User.Identity.IsAuthenticated;
            var user = context.HttpContext.RequestServices.GetRequiredService<IMaintenanceModeDataService>();
            if (!user.IsMaintenanceModeEnabled)
            {
                context.Result = new RedirectResult("/Home/privacy");
                return;
            }
            var httpContext = context.HttpContext;

            // get user name
            string userName = httpContext.User.Identity.Name;

            // check against list to see if access permitted
            return;

        }
    }
}
