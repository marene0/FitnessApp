//using Microsoft.AspNetCore.Mvc;
//using FitnessApp.Model;
//using FitnessApp.Services;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using FitnessApp.Interfaces;
//using FitnessApp.DTO;

//namespace FitnessApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class WorkoutController : ControllerBase
//    {
//        private readonly IWorkoutService _workoutService;

//        public WorkoutController(IWorkoutService workoutService)
//        {
//            _workoutService = workoutService;
//        }

//        [HttpGet("{workoutId:Guid}")]
//        public async Task<IActionResult> GetAll([FromRoute] Guid workoutId)
//        {

//            return Ok();
//        }

//        [HttpPost]
//        public async Task<IActionResult> GetWorkout([FromBody] WorkoutDTO workout)
//        {

//            return Ok();
//        }
//    }
//}




using Microsoft.AspNetCore.Mvc;
using FitnessApp.Model;
using FitnessApp.Interfaces;
using FitnessApp.DTO;
using FitnessApp.Services;
namespace FitnessApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Workout>>> GetAllWorkouts()
        {
            var workouts = await _workoutService.GetAllWorkoutsAsync();
            return Ok(workouts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutDTO>> GetWorkoutByIdAsync(Guid id)  
        {
            var workoutDto = await _workoutService.GetWorkoutByIdAsync(id);
            if (workoutDto == null)
            {
                return NotFound();
            }
            return Ok(workoutDto);
        }

        //[HttpPost("/create")]

        //public async Task<ActionResult<Workout>> CreateWorkout(Workout workout)
        //{
        //    var createdWorkout = await _workoutService.CreateWorkoutAsync(workout);
        //    return CreatedAtAction(nameof(GetWorkoutById), new { id = createdWorkout.Id }, createdWorkout);
        //}

        //[HttpPut("{workoutId:guid}")]
        //public async Task<IActionResult> UpdateWorkout(Guid id, Workout workout)
        //{
        //    var updatedWorkout = await _workoutService.UpdateWorkoutAsync(id, workout);
        //    if (updatedWorkout == null)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}


        [HttpPost]
        public async Task<IActionResult> CreateWorkoutAsync([FromBody] WorkoutDTO workoutDTO)
        {
         

            var createdWorkout = await _workoutService.CreateWorkoutAsync(workoutDTO);

            if (createdWorkout != null)
            {
                return Created();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create workout");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(Guid id)
        {
            var deleted = await _workoutService.DeleteWorkoutAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
