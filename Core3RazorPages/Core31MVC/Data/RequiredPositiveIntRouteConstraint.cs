using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core31MVC.Data
{
    public class RequiredPositiveIntRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext,
                            IRouter router,
                            string parameterName,
                            RouteValueDictionary values,
                            RouteDirection routeDirection)
        {
            var url = values["key"];
            
            return true;
        }
    }
}
