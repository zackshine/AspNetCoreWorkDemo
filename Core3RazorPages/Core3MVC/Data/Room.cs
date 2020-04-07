using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Data
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomTypeName { get; set; }
    }

    public class ReservationGuestDetail
    {
        [Key]
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int ReservationNumber { get; set; }

        public string GuestName { get; set; }
    }

    public class Reservation
    {
        [Key]
        public int ReservationNumber { get; set; }

        public string ReservationStatus { get; set; }

    }
}
