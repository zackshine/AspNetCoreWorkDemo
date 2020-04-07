using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ReactCore31.Controllers
{
    public partial class CreateGame
    {
        public virtual StarSystem StarSystem { get; set; }
        public virtual Ship Ship { get; set; }
    }

    public partial class StarSystem
    {
        public string Name { get; set; }
        public long Location { get; set; }
    }

    public partial class Ship
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long MaxCrew { get; set; }
    }
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
        [HttpPost]
        public async Task<ActionResult> ProcessForm([FromForm] CreateGame newGameEntry)
        {
            return Ok();
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
