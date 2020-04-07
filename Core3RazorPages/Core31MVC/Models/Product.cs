using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core31MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string ProductName { get; set; }


        public int ProductSubcategoryID { get; set; }

        

        public ProductSubcategory ProductSubcategory { get; set; }
    }

    public class ProductSubcategory
    {
        [Key]
        public int ProductSubcategoryID { get; set; }
        [Required]
        public int ParentCategoryID { get; set; }
        public ParentCategory ParentCategory { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string ProductSubcategoryDescription { get; set; }
    }

    public class ParentCategory
    {
        [Key]
        public int ParentCategoryID { get; set; }

        [Required]
        public string ParentCategoryDescription { get; set; }


        public IEnumerable<ProductSubcategory> ProductSubcategories { get; set; }
    }
}
