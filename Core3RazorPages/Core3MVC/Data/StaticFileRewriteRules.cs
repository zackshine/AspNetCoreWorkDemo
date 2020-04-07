using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Data
{
    public class StaticFileRewriteRules
    {

        public static void RedirectRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Path.Value.EndsWith("/DemoSignUp.html", StringComparison.OrdinalIgnoreCase))
            {
                context.HttpContext.Response.Redirect("/DemoSignUp");
                context.Result = RuleResult.EndResponse;
            }
           
        }

        public static void ReWriteRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Path.Value.EndsWith("/DemoSignUp", StringComparison.OrdinalIgnoreCase))
            {
                context.HttpContext.Request.Path = context.HttpContext.Request.Path.Value + ".html";

            }
        }

    }
}
