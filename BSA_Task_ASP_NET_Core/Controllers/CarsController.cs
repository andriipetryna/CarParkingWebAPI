using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BSA_Task;
using BSA_Task_ASP_NET_Core.Services;
using BSA_Task_ASP_NET_Core.Models;

namespace BSA_Task_ASP_NET_Core.Controllers
{
    [Produces("application/json")]
    [Route("api/Cars/")]
    public class CarsController : Controller
    {
        private ParkingService Parking { get; }
        public CarsController(ParkingService parking)
        {
            Parking = parking;
        }

        // GET api/Cars
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Parking.GetAllCars();
        }

        // GET api/Cars/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!Parking.ContainsCar(id))
            {
                return NotFound($"Parking does't contain car with ID {id}");
            }

            return Ok(Parking.GetCarById(id));
        }

        // POST api/Cars
        [HttpPost]
        public IActionResult Post([FromBody]CarDTO car)
        {
            if(car == null)
            {
                return BadRequest("Invalid data");
            }
            if (car.Balance < 0)
            {
                return BadRequest("Car balance must be non-negative number");
            }
            if (!Parking.IsCarTypeExists(car.Type))
            {
                return BadRequest($"Car type with number {car.Type} doesn't exist");
            }
            if(Parking.IsFull())
            {
                return BadRequest("Parking is full");
            }

            Parking.AddCar(car.Type, car.Balance);

            return Ok();
        }

        // DELETE api/Cars/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!Parking.ContainsCar(id))
            {
                return NotFound($"Parking does't contain car with ID {id}");
            }
            if (!Parking.RemoveCar(id))
            {
                return BadRequest($"Car with ID {id} has fines! Please pay fines before removing the car");
            }

            return Ok();
        }
    }
}
