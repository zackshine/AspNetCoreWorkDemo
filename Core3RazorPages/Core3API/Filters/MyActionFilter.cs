using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3API.Filters
{
    public class MyActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var request = context.HttpContext.Request.Path
            //if (!context.ModelState.IsValid)
            //{
            //    context.Result = new BadRequestObjectResult(
            //                                        context.ModelState);
            //}
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
