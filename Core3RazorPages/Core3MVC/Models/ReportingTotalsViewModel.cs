using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class ReportingTotalsViewModel
    {
        public DataTable MonthByMonth { get; set; }
        public DataTable MonthlyComparisons { get; set; }
        public DataTable Books_Issued_Location_Totals { get; set; }
        public DataTable Inventory_By_Location_Totals { get; set; }
        public DataTable Books_Issued_Vs_Closed { get; set; }
    }
}
