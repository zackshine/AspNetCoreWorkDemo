using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Filters
{
    public class TenantActionFilter : Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            int tenantId = 11;
            var controller = (ControllerBase)context.Controller;
            controller.HttpContext.Items.Add("TenantId", tenantId);
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
