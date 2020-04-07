using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models.Passengers
{
    public class FlightsViewModel
    {
        public int IdC { get; set; }
        public int IdF { get; set; }
        public string FNumber { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public string Destination { get; set; }
        public bool Attended { get; set; }

    }
}
