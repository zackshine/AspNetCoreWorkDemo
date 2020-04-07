using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core223MVC.Models;
using Core22MVCIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace Core223MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signInManager;

        public HomeController(SignInManager<ApplicationUsers> signInManager, UserManager<ApplicationUsers> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if(user != null)
            {
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
            }
           
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            
            var result = await _signInManager.PasswordSignInAsync("system@managementstudio.com", "P@ssw0rd", false, lockoutOnFailure: true);
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
