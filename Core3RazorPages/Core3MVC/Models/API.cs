using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class Api
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool isDeleted { get; set; }
        public List<ApiApplicant> ApiApplicants { get; set; }
    }

    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Type { get; set; }

        public List<ApiApplicant> ApiApplicants { get; set; }
    }
    public class ApiApplicant
    {
        //[Key]
        //public int Id { get; set; }
        public int? ApiId { get; set; }
        public int? ApplicantId { get; set; }
        public int ApiRequestDated { get; set; }
        public int? GateId { get; set; }
        [ForeignKey("GateId")]
        public Gate Gate { get; set; }
        public bool isDeleted { get; set; }
        [ForeignKey("ApiId")]
        public Api Api { get; set; }
        [ForeignKey("ApplicantId")]
        public Applicant Applicant { get; set; }
    }

    public class Gate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ApiApplicant> ApiApplicants { get; set; }
    }
}
