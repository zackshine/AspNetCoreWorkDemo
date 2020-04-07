using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core31API
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
    //[XmlRoot("WeatherForecasts")]
    //public class WeatherForecasts : List<WeatherForecast> { }
}
