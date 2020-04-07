using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core22APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestBindController : ControllerBase
    {
        public class RetrieveMultipleResponse
        {
            public List<Attribute> Attributes { get; set; }
            public string Name { get; set; }
            public string Id { get; set; }
        }

        public class Value
        {
            [JsonProperty("Value")]
            public string value { get; set; }
            public List<string> Values { get; set; }
        }

        public class Attribute
        {
            public string Key { get; set; }
            public Value Value { get; set; }
        }
        // GET: api/TestBind
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TestBind/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TestBind
        [HttpPost]
        public IActionResult Post([FromBody] RetrieveMultipleResponse value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { ErrorMessage = "bind fail" });
            }
            return Ok(value);
        }

        // PUT: api/TestBind/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
