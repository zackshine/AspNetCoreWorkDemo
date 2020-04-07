using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class FileInfo
    {
        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
