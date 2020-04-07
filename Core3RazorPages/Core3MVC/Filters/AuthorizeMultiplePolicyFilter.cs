using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Filters
{
    public class AuthorizeMultiplePolicyFilter : IAsyncAuthorizationFilter
    {
        private  IAuthorizationService _authorization;
        private  string[] _policies;
        

        public AuthorizeMultiplePolicyFilter(string[] policies)
        {
            _policies = policies;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Path.StartsWithSegments("/Home"))
            {
                return;
            }
          
            _authorization = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            foreach (var policy in _policies)
            {
                var authorized = await _authorization.AuthorizeAsync(context.HttpContext.User, policy);
                if (!authorized.Succeeded)
                {
                    if(policy == "UserIsAuthenticated")
                    {
                        context.Result = new RedirectResult("/Home/Privacy");
                    }
                    if(policy == "UserIsRegistered")
                    {
                        context.Result = new ForbidResult();
                    }
                    
                    return;
                }
            }

        }
    }
}
