using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class BugViewModel
    {
        public string Description { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
