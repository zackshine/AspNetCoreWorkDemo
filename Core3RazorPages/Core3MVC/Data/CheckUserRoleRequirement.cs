using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Data
{
    public class CheckUserRoleRequirement : IAuthorizationRequirement
    {
        public string RoleName { get; private set; }

        public CheckUserRoleRequirement(string roleName)
        {
            RoleName = roleName;
        }
    }

    public class CheckUserRoleHandler : AuthorizationHandler<CheckUserRoleRequirement>
    {
        private readonly IServiceProvider _serviceProvider;

        public CheckUserRoleHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       CheckUserRoleRequirement requirement)
        {
            if (!context.User.Claims.Any(x => x.Type == "Scope")
              && !context.User.Claims.Any(y => y.Type == "Scp"))
            {
                return Task.CompletedTask; // returned here without processing
            }
            var id = context.User.Identity.Name;
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
               
                var roles = dbContext.UserRoles.Where(s => s.RoleId == id).Select(s => s.RoleId.ToString()).ToList();
                if (roles != null && roles.Contains(requirement.RoleName))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
