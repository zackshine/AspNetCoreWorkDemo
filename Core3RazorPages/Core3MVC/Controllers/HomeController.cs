using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core3MVC.Models;
using Core3MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core3MVC.Models.Passengers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Core3MVC.Controllers
{

    [Flags]
    public enum AppliesOn : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Physical = 1,
        /// <summary>
        /// 
        /// </summary>
        Billing = 2,
        /// <summary>
        /// 
        /// </summary>
        Sendings = 4
    }
    public class StudentsVM
    {
        public long Id { get; set; }
        public long SubjectId { get; set; }
    }

    public class NameModel
    {
        public string  Name { get; set; }
    }
    public class MyModel
    {
        private int appliesOn;

        [BindProperty(BinderType = typeof(EnumToIntModelBinder))]
        public int AppliesOn
        {
            get { return appliesOn; }
            set { appliesOn = value; }
        }
    }
    //[AllowAnonymous]
    public class HomeController : Controller
    {
        private  ApplicationDbContext _context { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> TestEnum(string searchText, string currentFilter)
        {
            //ModelState.Clear();
            if (searchText != null)
            {
                
            }
            else
            {
                searchText = currentFilter;

            }

            ViewBag.CurrentFilter = searchText;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TestEnum(AttributeName attributeName)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SumEnumCheckBox(MyModel myModel)
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public void Complexi(IFormCollection input2)
        {

        }
       
        public IActionResult MyModel()
        {
            var model1 = new Model1()
            {
                Criteria = new List<string> { "sss", "ddd" }
            };
            return View(model1);
        }
        public IActionResult ViewName()
        {
            NameModel obj = new NameModel();
            return View("ViewName", obj);
        }
        [HttpPost]
        public IActionResult ViewName(NameModel obj1)
        {
            var model = new List<NameModel>();
            model.Add(obj1);
            return PartialView("_Tab2PartialView", model);

        }
        [Route("/Error/{statusCode}")]
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
        public IActionResult Passengers()
        {
            
            var model = new PassengerDetialsViewModel()
            {
                IdC = 1,
                Email = "111@163.com",
                FirstName = "Xing",
                Surname = "Zou",
                Flights = new List<FlightsViewModel>()
                {
                    new FlightsViewModel()
                    {
                        IdF = 100,
                        Attended = true,
                        Date = DateTime.Now,
                        Destination = "London",
                        Duration = "5h",
                        FNumber = "199505"
                    },
                    new FlightsViewModel()
                    {
                        IdF = 101,
                        Attended = true,
                        Date = DateTime.Now,
                        Destination = "New York",
                        Duration = "10h",
                        FNumber = "199605"
                    }
                }

            };
            return View(model);
        }


        public async Task<IActionResult> DeleteF(int IdC, int IdF)
        {
            if (IdC == null && IdF == null)
            {
                return NotFound();
            }

            var flightBooking = new FlightsViewModel()
            {
                IdC = IdC,
                IdF = IdF,
                Attended = true,
                Date = DateTime.Now,
                Destination = "New York",
                Duration = "10h",
                FNumber = "199605"
            };

            if (flightBooking == null)
            {
                return NotFound();
            }

            return View(flightBooking);
        }

        public JsonResult Get(int? page, int? limit, string searchString = null)
        {
            List<Student> records;
            var query = this._context.Student.Select(t => new Student
            {
                Id = t.Id,
                Name  = t.Name
                
            });

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(p => p.Name.Contains(searchString));
            }

            int total = query.Count();

            if (page.HasValue && limit.HasValue)
            {
                int start = (page.Value - 1) * limit.Value;
                records = query.Skip(start).Take(limit.Value).ToList();
            }
            else
            {
                records = query.ToList();
            }

            return Json(new { records, total });
        }
        public IActionResult Index()
        {
            string referer = Request.Headers["Referer"].ToString();
            var exceptionHandlerPathFeature =
    HttpContext.Features.Get<IExceptionHandlerPathFeature>();
           
            if (exceptionHandlerPathFeature?.Path == "/index")
            {
              
            }
            //var ress = _context.Student.Include(s => s.Grades).ToList();
            //return RedirectToAction("Index", "Default", new { area = "Dashboard" });
            //var dbContext = DbContextFactory.Create("DB2");
            //var movies = dbContext.Movie.ToList();
            string returnUrl = null;
            returnUrl ??= Url.Content("~/Account/feeds");
            var TotalWorkingHours = _context.Student.ToList().Count > 0 ? _context.Student.ToList().Sum(a => Int64.Parse(a.Name)) : 0;
            var res = _context.Student.Include(s => s.Grades).ThenInclude(g => g.Subject).ToList();

            string pathPortada = Path.Combine(_hostingEnvironment.WebRootPath);
            var NameModel = new NameModel();
            NameModel.Name = Path.Combine(pathPortada, "thieve.png");
            return View(NameModel);
        }
        [HttpPost]
        public async Task<JsonResult> SendBugReport(BugViewModel viewModel)
        {
            //Process Form
            //return NotFound();
            string message;
            bool isError;
            if(viewModel.Description == "111")
            {
                 message = "success";
                 isError = false;
            }
            else
            {
                 message = "error";
                 isError = true;
            }
            
            return Json(new { message, isError });
            //return PartialView("BugModal", viewModel);
        }
        public IActionResult GetJsonValue()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string path = Path.Combine(contentRootPath, "myData.json");
            var JSON = System.IO.File.ReadAllText(path);
            var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);
            return new JsonResult(jsonObj);
        }
        public IActionResult claimdocumentform()
        {
          
            var sevenItems = new byte[] { 0x20, 0x21, 0x22, 0x23, 0x20, 0x20, 0x20 };
            HttpContext.Session.Set("sessionuser", sevenItems);
            HttpContext.Session.SetString("SessionData", "The DDDD");
            return View();
        }
        //  [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Wazobia(IList<Models.FileInfo> fam)
        {

            return View();
        }

        //[HttpPost]
        //public void Privacy(Department ddd,string changedDropdown)
        //{
        //}
        //[Authorize(Policy = "AdminRole")]
        public async Task<IActionResult> Privacy()
        {

            var ss = new List<string> { "22", "33" };
            var join = string.Join( ",",ss);
            var sp = _context.Student.FromSqlRaw("Execute dbo.GetStudents @name = {0}", join);
            var sess = HttpContext.Session.GetByteArray("sessionuser");
            ViewBag.session = HttpContext.Session.GetString("SessionData");
            
            ViewBag.originalStationsList = _context.Departments.Select(c => new SelectListItem() { Text = c.DepartmentName, Value = c.Id.ToString() }).ToList();
            ViewBag.Departments = _context.Departments.ToList();
            return View(new Department());
        }

       
        public IActionResult AddSchool()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSchool(SchoolViewModel schoolViewModel)
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
