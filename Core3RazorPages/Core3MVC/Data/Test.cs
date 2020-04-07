using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Core3MVC.Data
{
    public class CheckADGroupRequirement : IAuthorizationRequirement
    {
        public string GroupName { get; private set; }

        public CheckADGroupRequirement(string groupName)
        {
            GroupName = groupName;
        }
    }
    public class CheckADGroupHandler : AuthorizationHandler<CheckADGroupRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       CheckADGroupRequirement requirement)
        {
            //var isAuthorized = context.User.IsInRole(requirement.GroupName);

            var groups = new List<string>();//save all your groups' name
            var wi = (WindowsIdentity)context.User.Identity;
            if (wi.Groups != null)
            {
                foreach (var group in wi.Groups)
                {
                    try
                    {
                        groups.Add(group.Translate(typeof(NTAccount)).ToString());
                    }
                    catch (Exception e)
                    {
                        // ignored
                    }
                }
                if (groups.Contains(requirement.GroupName))//do the check
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
