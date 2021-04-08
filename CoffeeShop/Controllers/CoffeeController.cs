using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using CoffeeShop.Repositories;
namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {

        private readonly ICoffeeRepo _coffeeRepo;
        public CoffeeController(ICoffeeRepo coffeeRepo)
        {
            _coffeeRepo = coffeeRepo;
        }



        // https://localhost:5001/api/coffee/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_coffeeRepo.GetAllCoffees());
        }


        // https://localhost:5001/api/coffee/
        [HttpPost]
        public IActionResult Post(Coffee coffee)
        {
            _coffeeRepo.AddCoffee(coffee);
            return CreatedAtAction("Get", new { id = coffee.Id }, coffee);
        }

      


    }
}
