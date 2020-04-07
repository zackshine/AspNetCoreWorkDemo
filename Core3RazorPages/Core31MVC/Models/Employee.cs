using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core31MVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Img1 { get; set; }

       
        public virtual EmployeeDepartment EmployeeDepartment { get; set; }
    }

   
    public class EmployeeDepartment
    {
        [Key]
        public int DeptID { get; set; }

        [ForeignKey("Employee")]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        public string DeptName { get; set; }
        [JsonProperty("RegionId")]
        public virtual Employee Employee { get; set; }
    }
}
