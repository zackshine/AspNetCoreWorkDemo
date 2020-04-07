using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models.Passengers
{
    public class PassengerDetialsViewModel
    {
        [Display(Name = "Passenger ID ")]
        public int IdC { get; set; }

        [Display(Name = "Surname ")]
        [Required]
        public string Surname { get; set; }

        [Display(Name = "First Name ")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "E-mail Address ")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public IEnumerable<FlightsViewModel> Flights { get; set; }
    }

   
}
