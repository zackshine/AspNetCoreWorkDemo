using Core3API.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core3API.Filters
{
    public class MyResourceFilters : IResourceFilter
    {
       
     

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var dataSource = new User()
            {
                Name = "hello",
                DName = "world"
            };
            var json = JsonConvert.SerializeObject(dataSource);
            //replace request stream to downstream handlers
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            //context.HttpContext.Request.Body =  requestContent.ReadAsStreamAsync();//modified stream      
        }
    }

    
public class ResourceFilter : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(
            ResourceExecutingContext context,
            ResourceExecutionDelegate next)
        {
            Console.WriteLine("Executing async!");
            using (StreamReader reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8))
            {
                var stt = await reader.ReadToEndAsync();
                var dataSource = new User()
                {
                    Name = "hello",
                    DName = "world"
                };
                    var json = JsonConvert.SerializeObject(dataSource);
                    //replace request stream to downstream handlers
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/problem+json");
                context.HttpContext.Request.Body = await requestContent.ReadAsStreamAsync();//modified stream               
            }
            ResourceExecutedContext executedContext = await next();
            Console.WriteLine("Executed async!");
        }
    }
}
