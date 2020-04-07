using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core31API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async IAsyncEnumerable<WeatherForecast> Get()
        {
            var date = DateTime.Now;
            await Task.Delay(0);
            var rng = new Random();

            for (var index = 1; index < 5; index++)
            {
                yield return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };
            }
        }
        //[HttpGet]
        //public WeatherForecasts Get()
        //{
        //    var rng = new Random();
        //    var x = new WeatherForecasts();
        //    var y = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToList();
        //    x.AddRange(y);
        //    return x;
        //}

        [HttpGet("Createnewlead")]
        public IActionResult LeadCreate([FromQuery]CRM_Lead Lead)
        {
            return Ok(Lead);
        }

        [HttpPost("Test")]
        public IActionResult Test([FromBody]CRM_Lead Lead)
        {
            return Ok(Lead);
        }
    }

    public class CRM_Lead
    {
        [Required]
        public int RegionID { get; set; }
        public string CardName { get; set; }
    }
}
