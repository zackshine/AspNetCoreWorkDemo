using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core22MVCIdentity.Models;
using Core22MVCIdentity.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Core22MVCIdentity.Controllers
{
    public class ServerModel
    {
        public string serverName { get; set; }
        public string port { get; set; }
    }
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("{statusCode}")]
        public IActionResult Error(int statusCode = 0)
        {
            switch (statusCode)
            {
                case 404:
                    return View();
                case 500:
                    return View("BadRequest");
            }

            return View("Error");
        }
        public async Task XYZ2(string SName, string CName, Int16 CId)
        {//for route#2
        }
        public async Task XYZ1(string TName, Int64 MId)
        {//for route#1
        }
                public IActionResult Index()
        {
            var panels = _context.Panels
               .Include(p => p.Frame)
               .ToList();
            //string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
            //var card = new SpecialCard()
            //{
            //    //SpecialCardText = "special",
            //    Context = "qwe",
            //    Receiver = "hello"
            //};
            //_context.Add(card);
            //_context.SaveChanges();
            ViewData["Session"] = 0;
            return View(new Core22MVCIdentity.Areas.Document.Controllers.LocalUserViewModel() { Id=1});
        }

        [HttpPost]
        public JsonResult Test([FromBody] ServerModel data)
        {
            try
            {
                if (string.IsNullOrEmpty(data.serverName) ||
                    string.IsNullOrEmpty(data.port))
                {
                    return Json(new { Status = "Error", Message = "Missing Data" });
                }
                else
                {
                    return Json(new { Status = "Success", Message = "Got data" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Status = "Error", Message = e.Message });
            }
        }

        [HttpPost]
        public void CreateNewPanel([FromBody]Panels panel)
        {

            _context.Panels.Add(panel);
            _context.SaveChanges();

           // return CreatedAtAction(nameof(GetPanelById), new { id = panel.ID }, panel);
        }
        public IActionResult Privacy()
        {

            //var x = _context.Cards.Where(c=>c.Discriminator)
            var x = _context.Cards.ToList();
            var employee = _context.Cards.OfType<SpecialCard>().ToList();
                //Select(
            //  a => new SpecialCard
            //  {
            //      ID = a.ID,
            //      Receiver = a.Receiver,
            //      Context = a.Context,
            //      SpecialCardText = "Programmer"
            //  }).ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
