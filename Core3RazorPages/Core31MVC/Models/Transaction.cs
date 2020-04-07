using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core31MVC.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ResponseCode { get; set; }
        public int Amount { get; set; }
    }
}
