//using FitnessApp.DTO;
//using FitnessApp.Interfaces;
//using FitnessApp.Model;
//using FitnessApp.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace FitnessApp.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class GoalController : Controller
//    {
//        private readonly IGoalService _goalService;

//        public GoalController(IGoalService goalService)
//        {
//            _goalService = goalService;
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Goal>> GetGoalsById(Guid id)
//        {
//            var goal = await _goalService.GetGoalByIdAsync(id);
//            if (goal == null)
//            {
//                return NotFound();
//            }
//            return Ok(goal);
//        }


//        [HttpPost]
//        public async Task<IActionResult> CreateGoalAsync([FromBody] GoalDTO goalDTO)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var createdGoal = await _goalService.CreateGoalAsync(new Goal
//            {
//                Description = goalDTO.Description,
//                Count = goalDTO.Count
//            });

//            if (createdGoal != null)
//            {
//                return Created();
//            }
//            else
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create goal");
//            }
//        }


//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteGoal (Guid id)
//        {
//            var deleted = await _goalService.DeleteGoalAsync(id);
//            if (!deleted)
//            {
//                return NotFound();
//            }
//            return NoContent();
//        }














//    }

//}
