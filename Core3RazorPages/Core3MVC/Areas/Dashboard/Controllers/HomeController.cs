using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Core3MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        private readonly IOptions<GlobalData> _globalData;

        public HomeController(IOptions<GlobalData> globalData)
        {
            _globalData = globalData;
        }
        public IActionResult Index()
        {
            var x = _globalData.Value.CompanyCode;
            return View();
        }
    }
}