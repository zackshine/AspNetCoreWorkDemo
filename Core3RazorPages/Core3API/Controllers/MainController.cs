using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core3API.Controllers
{
    public class Mymodel
    {
        public List<ProcessModel> Process { get; set; }
    }
    public class ProcessModel
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("ExeName")]
        public string ExeName { get; set; }
        [JsonProperty("Path")]
        public string Path { get; set; }
        [JsonProperty("VersionPath")]
        public string VersionPath { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("Ver")]
        public string Ver { get; set; }
        [JsonProperty("Args")]
        //public string[] Args { get; set; }
        public Dictionary<string, string> Args { get; set; }

        [JsonProperty("Multiple")]
        public string Multiple { get; set; }
    }

    public class Arg
    {
        public string Name { get; set; }
        public string value { get; set; }
    }
    [Route("api/vm")]
    //[ApiController]
    public class MainController : Controller
    {
        [HttpPost]
        [Route("Process")]
        public  void GetProcess([FromBody]List<ProcessModel> Process)
        {
               
        }
    }
}
