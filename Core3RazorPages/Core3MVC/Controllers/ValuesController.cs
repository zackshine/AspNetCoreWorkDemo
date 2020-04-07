using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3MVC.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core3MVC.Controllers
{
    public class MyViewModel
    {
        public string zipcode { get; set; }
        public int searchRadius { get; set; }
        public string ProductCodes { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [TenantActionFilter]
        public IActionResult Get()
        {
            var id = HttpContext.Items["TenantId"]?.ToString();
            int tenantId;
            if (!int.TryParse(HttpContext.Items["TenantId"].ToString(), out tenantId))
            {
                tenantId = -1;
            }
            return new JsonResult(tenantId);
        }
        [HttpPost("ForwardInfo")]
        //public IActionResult FowardInfo(string zipcode, int searchRadius, string ProductCodes)
        public IActionResult FowardInfo([FromBody] MyViewModel value)
        {
            string Zipcode = value.zipcode;
            int SearchRadius = value.searchRadius;
            string ProductCode = value.ProductCodes;
            // ...
            return new JsonResult(Zipcode);
        }
    }
}