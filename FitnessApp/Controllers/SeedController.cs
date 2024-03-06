using Microsoft.AspNetCore.Mvc;
using FitnessApp.Data;

namespace FitnessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SeedController : Controller
    {
        
        private readonly SeedingService _seed;

        public SeedController( SeedingService seed)
        {
            _seed = seed;
            
        }

        [HttpGet]
        public IActionResult GetSeed()
        {

            _seed.SeedDataContext();
            return Ok("Database seeding successful");

        }

        [HttpGet("user")]
        public IActionResult GetSeedUser()
        {

            _seed.SeedDataContext();
            return Ok("Database User seeding successful");

        }
        
        [HttpGet("workout")]
        public IActionResult GetSeedWorkout()
        {

            _seed.SeedDataContext();
            return Ok("Database User Workout seeding successful");

        }

        //[HttpGet("goal")]
        //public IActionResult GetSeedGoal()
        //{

        //    _seed.SeedDataContext();
        //    return Ok("Database  Goal seeding successful");

        //}


    }

}
