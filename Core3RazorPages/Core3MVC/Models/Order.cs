using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public ICollection<OrderDetail> Details { get; set; }
    }

    public class OrderDetail
    {
        public int OrderDetailID { get; set; }        
        public int OrderID { get; set; }
        
        public string Description { get; set; }
        public Order Order { get; set; }
    }
}
