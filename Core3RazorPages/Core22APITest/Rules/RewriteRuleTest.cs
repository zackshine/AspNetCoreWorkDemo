using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22APITest.Rules
{
    public class RewriteRuleTest : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            var path = request.Path.Value;

            if (path.ToLower() == "/employees/")
            {                
                context.HttpContext.Request.Path = "/employees/0";
            }
        }
    }
}
