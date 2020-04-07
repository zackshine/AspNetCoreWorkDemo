using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core31MVC.Models
{
    public class Model
    {
        [Display(Name = "ID")]
        public long? Id { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<FileModel> Files { get; set; }
    }
    public class FileModel
    {
        [HiddenInput(DisplayValue = false)]
        public long? Id { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Link")]
        public bool Link { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
    }
}
