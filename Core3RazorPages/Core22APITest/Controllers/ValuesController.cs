using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Core22APITest.Controllers
{
    public class GetUserReviewsRequest
    {
        [Required, FromQuery]
        public ReviewStatus? Status { get; set; }
    }

    [Flags]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReviewStatus
    {
        Processing = 1,
        Published = 2,
        Declined = 4,
        Rated = 16,
        Unrated = 32
    }

    [Route("api/[controller]")]
    //[ApiController]
    public class ValuesController : Controller
    {

        [HttpGet]
        [Route("/reviews")]
        public async Task<IActionResult> GetReviews(GetUserReviewsRequest request)
        {
            return Ok();
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
//            var message = new MimeMessage();
//            message.From.Add(new MailboxAddress("Xing Zou", "zou19950516@gmail.com"));
//            message.To.Add(new MailboxAddress("Xing Zou", "zackshine@163.com"));
//            message.Subject = "How you doin'?";

//            message.Body = new TextPart("plain")
//            {
//                Text = @"Hey Chandler,

//I just wanted to let you know that Monica and I were going to go play some paintball, you in?

//-- Joey"
//            };

//            using (var client = new SmtpClient())
//            {
//                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
//                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

//                client.Connect("smtp.gmail.com", 587, false);

//                // Note: only needed if the SMTP server requires authentication
//                client.Authenticate("zou19950516@gmail.com", "zou19950516");

//                client.Send(message);
//                client.Disconnect(true);
//            }
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpPost("{id}")]
        public async Task<ActionResult<string>> Get(int id,IFormFile file)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Xing Zou", "zou19950516@gmail.com"));
            message.To.Add(new MailboxAddress("Xing Zou", "zackshine@163.com"));
            message.Subject = "How you doin'?";
            var builder = new BodyBuilder();
            builder.TextBody =
            @"Hey Chandler,

            I just wanted to let you know that Monica and I were going to go play some paintball, you in?

            -- Joey";

            //var builder = new BodyBuilder { HtmlBody = message.Body };
            if (file != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    builder.Attachments.Add(file.FileName, memoryStream.ToArray());
                }

            }
            //builder.Attachments.Add()
            message.Body = builder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("zou19950516@gmail.com", "zou19950516");

                client.Send(message);
                client.Disconnect(true);
            }
            return "value";
        }

      

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("/Employees/{EmpID}")]
        public int Delete(int empID)
        {
            if (empID == 0)
            {
                return 100;
            }
            else
            {
                return empID;
            }
        }

        [HttpDelete("/Employees")]
        public string Delete()
        {
            return "/Employees";
        }
    }
}
