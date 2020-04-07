using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core31MVC.Models
{
    public class CMyBindModel
    {
        public int ProductQuantity{get; set; }    // Binding Data

 
    }

    public class CMyViewModel 
    {
        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public string ProductName{get; set; }    // Display Data
        [Required]
        public string ProductDescription { get; set; }
        // Other Display properties ...
    }
}
