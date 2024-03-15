using FitnessApp.DTO;
using FitnessApp.Interfaces;
using FitnessApp.Model;
using FitnessApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalController : Controller
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }
     
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<GoalDTO>>> GetGoalsByUserIdAsync(Guid userId)
        {
            var goals = await _goalService.GetGoalsByUserIdAsync(userId);
            if (goals == null)
            {
                return NotFound();
            }
            return Ok(goals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoalAsync([FromBody] GoalDTO goalDTO)
        {


            var createdGoal = await _goalService.CreateGoalAsync(goalDTO);

            if (createdGoal != null)
            {
                return Created();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create workout");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(Guid id, [FromBody] GoalDTO updatedGoal)
        {
            var success = await _goalService.UpdateGoalAsync(id, new Goal
            {
                Description = updatedGoal.Description,
                Count = updatedGoal.Count
            });

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(Guid id)
        {
            var success = await _goalService.DeleteGoalAsync(id);
            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
