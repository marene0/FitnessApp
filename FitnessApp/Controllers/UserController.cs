using FitnessApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IWorkoutService _workoutService;

        public UserController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("{userId:Guid}/workouts")] // from Token 
        public async Task<IActionResult> GetUserWorkoutsl([FromRoute] Guid userId)
        {
            var workouts = await _workoutService.GetAllWorkoutsAsync(userId);
            return Ok(workouts);
        }
    }
}
