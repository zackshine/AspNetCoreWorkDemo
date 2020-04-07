using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core3API.Filters;
using Core3API.JsonConverter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

namespace Core3API.Controllers
{
    public class User
    {       
        public string Name { get; set; }
        public string DName { get; set; }
    }
    public class GetUserReviewsRequest
    {
        [Required, FromQuery]
        public ReviewStatus? Status { get; set; }
    }

    [Flags]
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum ReviewStatus
    {
        Processing = 1,
        Published = 2,
        Declined = 4,
        Rated = 16,
        Unrated = 32
    }
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int temperatureC { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string summary { get; set; }
    }
    //[JsonConverter(typeof(HeadingJsonConverter))]
    public class Heading
    {
        
        public string Title { get; }
        public Heading(string title)
        {
            Title = title;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ValuesController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("testIgnore")]
        public void PostData([FromBody] WeatherForecast body)
        {
            string ignored = JsonConvert.SerializeObject(body);
            var test = JsonConvert.DeserializeObject<WeatherForecast>(ignored);
        }
        // GET api/values
       
        [HttpGet]
        [Route("/reviews")]
        public async Task<IActionResult> GetReviews([FromQuery]GetUserReviewsRequest request) 
        {
            return Ok();
        }

        
        [HttpPost("MyMethod")]
        public string MyMethod(object model)
        {
            var xx = ((dynamic)model).Valuesss["value1"].Value;
            //var data = (JObject)model;
            //var items = data.SelectToken("Values").Children().OfType<JProperty>().ToDictionary(p => p.Name, p => p.Value);
            //foreach (var item in items)
            //{
            //    if (item.Key == "value1")
            //    {
            //        var x = (string)item.Value;
            //    }
            //}
                //  var dd = content.Value<object>();
                // PropertyInfo modelProperty = content.GetType().GetProperty("Values");
                // var modelValue = modelProperty.GetValue(model);
                // var xx = content.Children().OfType<JProperty>().ToDictionary(p => p.Name, p => p.Value);
                //var xx = x.Substring(1, x.Length - 2);
                //var x = content.GetValue("Values");

                return "xx";
        }
        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id, [RequiredFromQuery]string foo, [RequiredFromQuery]string bar)
        //{
        //    return id + " " + foo + " " + bar;
        //}

        [HttpPost("[action]")]
        public async Task<User> verifydata(User model)
        {
            return model;
        }
       
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Heading value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<string> PutAsync(int id, [FromBody] string value)
        {
            var cc = (string)HttpContext.Items["body"];
            var ccccc = "";
            Request.EnableBuffering();
            using (var reader = new StreamReader(Request.Body, encoding: System.Text.Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                ccccc = body;
                Request.Body.Position = 0;
            }
            return ccccc;
        }


        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok();
        }
        // DELETE api/values/5
        [HttpDelete("/Employees/{id?}")]
        public int Delete(int? id)
        {
            if (id > 0)
            {
                return (int)id;
            }
            else
            {
                return 100;
            }
        }

        [HttpDelete("/Employees")]
        public string Delete()
        {
            return "/Employees";
        }
    }
}
