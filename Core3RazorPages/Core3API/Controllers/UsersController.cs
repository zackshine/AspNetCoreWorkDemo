using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core3API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        [HttpPost("Test")]
        public IActionResult ProcessData([FromForm]IFormFile file)
        {
            return Ok();
            // Method never gets called
        }
        [HttpPost("{data1}/{data2}")]
        public IActionResult ProcessData(string data1, string data2)
        {
            return Ok();
            // Method never gets called
        }
        public String Test()
        {
            return "Hier werden User registriert";
            //Get Values from Form and Send to Service
        }

        [HttpPost]
        public String Register()
        {
            return "Hier werden User registriert";
            //Get Values from Form and Send to Service
        }

        [HttpPost]
        public String Login()
        {
            return "Hier werden User eingeloggt";
            //Get Values from Form and Send to Service
        }

        [HttpPut]
        public String ResetPWD(int ID, String Password)
        {
            return "Hier können User Ihr Passwort ändern";
            //Get Values from Form and Send to Service
        }
    }
}