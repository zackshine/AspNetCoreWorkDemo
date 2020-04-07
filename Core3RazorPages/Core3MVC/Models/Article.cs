using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? PreviousId { get; set; }
        public Article Previous { get; set; }
        public int? NextId { get; set; }
        public Article Next { get; set; }
    }
}
