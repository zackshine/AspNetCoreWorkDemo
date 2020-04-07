using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class App
    {
        public int ID { get; set; }
        public int MonAlertsID { get; set; }

        public string AppName { get; set; }

        public string AlertType { get; set; }
        public bool Active { get; set; }
    }
}
