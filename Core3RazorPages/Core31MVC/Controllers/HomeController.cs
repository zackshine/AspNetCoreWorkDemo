using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core31MVC.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Core31MVC.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace Core31MVC.Controllers
{
    public class Login
    {
        public string uname { get; set; }
        public string pwd { get; set; }
    }
    public class Restaurant
    {
        public string RestaurantName { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        private readonly IMyApplicationAppService _services;
        public HomeController(IMyApplicationAppService services, IHostingEnvironment hostingEnv, ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _services = services;
            _hostingEnv = hostingEnv;
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task Testjson()
        {
            List<PrometheusJson> dataG = new List<PrometheusJson>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient
                    .GetAsync("https://localhost:44326/home/GetJson"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<PrometheusJson>(apiResponse);
                    dataG.Add(data);
                }
                Console.WriteLine(dataG);
            }
        }

        public JsonResult GetJson()
        {
            string allText = System.IO.File.ReadAllText(@"C:\Workspace\aspcore3Practice\Core3RazorPages\Core31MVC\wwwroot\test.json");

            object jsonObject = JsonConvert.DeserializeObject<PrometheusJson>(allText);
            return Json(jsonObject);
        }
        public IActionResult Download([FromQuery]string path)
        {

            string fileName = "test.txt";

            byte[] fileBytes = System.IO.File.ReadAllBytes(path);

            return File(fileBytes, "application/force-download", fileName);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Cart()
        {
            CMyViewModel viewModel = new CMyViewModel()
            {
                ProductName = "Apple",
                ProductDescription = "xxxxx",
                ProductQuantity = 123
            };
            return View(viewModel);
        }

        public void RemoveDisplayingDataValidation()
        {
            ModelState.Remove("ProductName");
            ModelState.Remove("ProductDescription");
        }

        [HttpPost]
        public IActionResult Cart(CMyViewModel viewmodel)
        {
            RemoveDisplayingDataValidation();
            if (ModelState.IsValid)
            {
                return RedirectToAction("Cart");
            }

            CMyViewModel viewModel = new CMyViewModel()
            {
                ProductName = "Pear",
                ProductQuantity = 100
            };
            return View(viewModel);
        }
        public IActionResult File(string image)
        {
            return View();
        }

        public async Task<int> GetTransactionsAmountSumWithinAMonth(DateTime month)
        {
            var monthString = month.ToString("MM/yyyy");
            var trans = _context.Transactions.AsNoTracking()
                              .AsEnumerable()
                              .Where(c => (c.DateCreated.ToString("MM/yyyy") == monthString) && (c.ResponseCode == "00"))
                              .Select(c => c.Amount)
                              .ToList();
            var sum = trans.Sum();
            return sum;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(IFormFile myFile)
        {

            var fileName = Path.GetFileName(myFile.FileName);
            using (var ms = new MemoryStream())
            {
                myFile.CopyTo(ms);
                byte[] fileBytes = ms.ToArray();

            }
            
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            //var file = _services.ExportV2();
            var monthSum = new List<int>();
            DateTime[] lastSixMonths = Enumerable.Range(0, 6).Select(i => DateTime.Now.AddMonths(-i)).ToArray();

            foreach (var month in lastSixMonths)
            {
                var data = await GetTransactionsAmountSumWithinAMonth(month);
                monthSum.Add(data);
            }
            // var add = _pushNotificationRepository.Add();
            var x = _userManager.GetUserId(User);
            var xx = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        public async Task<IActionResult> Privacy()
        {

            var list = new List<int> { 1, 2, 3, 4 };
            var responsew = _context.Movies.Include(ba => ba.MovieVersions)
                .AsEnumerable()
                .Where(ba => ba.Name.ToString() == "Heelo" &&

                list.Contains(ba.Id))

                    //.Where(ba => ba.MovieVersions.Any(x => x.Name.Equals("version1")))

                    .OrderBy(ba => ba.Id)
                    .Skip(1)
                    .Take(500)
            .ToList();
            Request.RouteValues.TryAdd("token", "ssss");
            this.AddNotification("User successfully added!");
            return View();
        }
        public IActionResult SaveImage()
        {
            var rest = new Restaurant()
            {
                RestaurantName = "hello"
            };
            return View(rest);
        }
        [HttpPost]
        public void SaveImage(string imageData, string imageName)
        {

            var filePath = Path.Combine(_hostingEnv.ContentRootPath, "images", imageName);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))

                {
                    imageData = imageData.Replace("data:image/jpeg;base64,", "");
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
        }
        public IActionResult ModelPost()
        {
            var x = Request.RouteValues["token"];
            var model = new Model()
            {
                Id = 123,
                Description = "TestModel",
                Files = new List<FileModel>()
                {
                    new FileModel()
                    {
                        Id=1,
                        Description = "file1 context",
                        Link =true
                    },
                    new FileModel()
                    {
                        Id=2,
                        Description = "file2 context",
                        Link =true
                    }
                }
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model model)
        {
            // saving to DB, additional validation, etc
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
