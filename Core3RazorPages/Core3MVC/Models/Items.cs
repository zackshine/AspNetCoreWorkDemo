using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public virtual TestUser User { get; set; }
    }

    public class TestUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Dob { get; set; }
        public string Location { get; set; }
        public ICollection<Items> Items { get; set; }
    }
}
