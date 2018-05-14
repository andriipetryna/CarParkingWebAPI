using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BSA_Task;
using BSA_Task_ASP_NET_Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSA_Task_ASP_NET_Core.Controllers
{
    [Produces("application/json")]
    [Route("api/Parking/[action]")]
    public class ParkingController : Controller
    {
        private ParkingService Parking { get; }

        public ParkingController(ParkingService parking)
        {
            Parking = parking;
        }

        // GET: api/Parking/Balance
        [HttpGet]
        public decimal Balance()
        {
            return Parking.GetParkingBalance();
        }
        // GET: api/Parking/AvailableSpace
        [HttpGet]
        public int AvailableSpace()
        {
            return Parking.GetAvailableParkingSpace();
        }
        // GET: api/Parking/UnavailableSpace
        [HttpGet]
        public int UnavailableSpace()
        {
            return Parking.GetUnavailableParkingSpace();
        }
    }
}
