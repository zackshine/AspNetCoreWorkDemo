using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Core30MVC.Controllers
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }
    public class HomeTest : Controller
    {
        public static List<Student> studentList = new List<Student>()
        {
            new Student {StudentId = 1, Name = "John"},
            new Student {StudentId = 2, Name = "Doe"},
        };

        public IActionResult Index()
        {
            return View(studentList);
        }

        public IActionResult Find(int id)
        {
            var student = studentList.Where(x => x.StudentId == id).FirstOrDefault();
            return new JsonResult(student);
        }

        [HttpPost]
        [Route("updateStudent")]
        public IActionResult updateStudent(int id, int name)
        {
            //var student = studentList.Where(x => x.StudentId == id).FirstOrDefault();
            //studentList.RemoveStudent();
            //var newStudent = new Student { StudentId = id, Name = name };
            //studentList.Add(newStudent);

            return RedirectToAction("Index");
        }
    }
}