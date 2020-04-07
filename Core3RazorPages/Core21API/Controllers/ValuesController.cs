using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Core21API.Controllers
{
    [Route("/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Student inputContext)
        {
            //var outputContext = Process(inputContext);
            return StatusCode(200, inputContext);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("/Employees/{EmpID?}")]
        public int Delete1(int? empID)
        {
            if (empID == 0)
            {
                return 100;
            }
            else
            {
                return (int)empID;
            }
        }

        [HttpDelete("/Employees")]
        public string Delete2()
        {
            return "/Employees";
        }
    }
}
