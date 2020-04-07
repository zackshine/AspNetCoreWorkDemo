using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class Student
    {
        [Key]
        public long Id { get; set; }

       [Required]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public long RegistrationNumber { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
    public class Grade
    {
        [Key]
        public long Id { get; set; }
        public int Value { get; set; }

        public long StudentId { get; set; }
        public virtual Student Student { get; set; }

        public long SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }

    public class Subject
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
