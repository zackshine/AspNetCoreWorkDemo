using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class AttributeName
    {
        [Required(ErrorMessage = "Attribute Type is required")]
        public AttributeType AttributeType { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string searchText { get; set; }
    }

    public enum AttributeType
    {
        List = 1,
        Text = 2,
        Number = 3,
        Decimal = 4
    }
}
