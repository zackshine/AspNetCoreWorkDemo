using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3API.Filters
{
   
        public class RewriteRuleTest : IRule
        {
            public void ApplyRule(RewriteContext context)
            {
                var request = context.HttpContext.Request;
                var path = request.Path.Value;
                if(path != null)
                //if (path.ToLower() == "/weatherforecast")
                {
                    context.HttpContext.Request.Path = path + "/" + request.Method;
                }
            }
        }
    
  
}
