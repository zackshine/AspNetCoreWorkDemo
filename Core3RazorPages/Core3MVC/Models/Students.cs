using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class SchoolViewModel
    {
        public string Name { get; set; }
        public List<Students> Students { get; set; }
    }

    public class Students
    {
        public string StudentsName { get; set; }
        public int Age { get; set; }
    }
}
