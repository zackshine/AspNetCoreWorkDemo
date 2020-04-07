using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core30MVC.Models;
using System.Net.Http;
using System.IO;

namespace Core30MVC.Controllers
{
    public class HomeController : Controller
    {
    
        public async Task<IActionResult> Index()
        {

            var getCategory = new List<string> {"css" ,"js"};
            ViewBag.Category = getCategory;

            var data = new List<IEnumerable<string>>();

            foreach (string category in getCategory)
            {
                var images = Directory.EnumerateFiles(@"C:\Workspace\aspcore3Practice\Core3RazorPages\Core30MVC\wwwroot\" + category).Select(fn => "~/" + category + "/" + Path.GetFileName(fn));
                data.Add(images);
            }
            ViewBag.Images = data;
            //using (var client = new HttpClient())
            //{
            //    var result = await client.PostAsync($"https://localhost:44329/Users/1/2", null);
               
            //}


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
