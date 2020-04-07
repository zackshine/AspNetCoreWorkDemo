using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Data
{
    public class RewriteRuleTest : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            if(request.Method == "GET")
            {
                if (!request.Path.Value.ToLower().EndsWith("/"))
                {
                    context.HttpContext.Response.Redirect($"{request.Path.Value}/");
                    context.Result = RuleResult.SkipRemainingRules;
                }
            }
            
        }
    }
}
