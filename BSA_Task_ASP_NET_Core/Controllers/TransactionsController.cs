using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BSA_Task;
using BSA_Task_ASP_NET_Core.Services;

namespace BSA_Task_ASP_NET_Core.Controllers
{
    [Produces("application/json")]
    [Route("api/Transactions/[action]")]
    public class TransactionsController : Controller
    {
        private ParkingService Parking { get; }

        public TransactionsController(ParkingService parking)
        {
            Parking = parking;
        }

        // GET: api/Transactions/Log
        [HttpGet]
        public IActionResult Log()
        {
            try
            {
                return Ok(Parking.GetTransactionsLog());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        // GET: api/Transactions/LastMinuteHistory
        [HttpGet]
        public IEnumerable<Transaction> LastMinuteHistory()
        {
            return Parking.GetLastMinuteTransactions();
        }

        // GET: api/Transactions/LastMinuteHistory/5
        [HttpGet("{id}")]
        public IActionResult LastMinuteHistory(int id)
        {
            if(!Parking.ContainsCar(id))
            {
                return NotFound($"Parking does't contain car with ID {id}");
            }

            return Ok(Parking.GetLastMinuteTransactions(id));
        }

        // PUT: api/Transactions/RechargeCarBalance/5
        [HttpPut("{id}")]
        public IActionResult RechargeCarBalance(int id, [FromBody]decimal rechargeSum)
        {
            if(!Parking.ContainsCar(id))
            {
                return NotFound($"Parking does't contain car with ID {id}");
            }
            if (rechargeSum <= 0)
            {
                return BadRequest("Recharge sum must be positive number");
            }

            Parking.RechargeCarBalance(id, rechargeSum);
            return Ok();
        }
    }
}
