using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3MVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Core3MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _DbEntity;
        public RoomsController(ApplicationDbContext context)
        {
            _DbEntity = context;
        }
        public IActionResult Get()
        {
           // var broswer = HttpContext.Request.Headers["User-Agent"].FirstOrDefault();

            var _list = (
                    from R in _DbEntity.Room
                    join G in _DbEntity.ReservationGuestDetail on R.RoomNumber equals G.RoomNumber into RG
                    from x in RG.DefaultIfEmpty()

                    join RE in _DbEntity.Reservation on x.ReservationNumber equals RE.ReservationNumber into GRE
                    from y in GRE.DefaultIfEmpty()

                    select new
                    {
                        RoomId = R.RoomId,
                        RoomNumber = R.RoomNumber,
                        RoomType = R.RoomTypeName,

                        ReservationNumber = y.ReservationNumber,
                        ReservationStatus = y.ReservationStatus,
                        GuestName = x.GuestName
                    }).OrderBy(x => x.RoomId).ToList();

            return Ok(_list);
        }
    }
}