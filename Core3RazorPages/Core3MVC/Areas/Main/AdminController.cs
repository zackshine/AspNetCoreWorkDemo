using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Core3MVC.Areas.Main
{
    [Area("Main")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}