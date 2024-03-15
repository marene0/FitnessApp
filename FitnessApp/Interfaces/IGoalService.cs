using FitnessApp.DTO;
using FitnessApp.Model;

namespace FitnessApp.Interfaces
{
    public interface IGoalService 
    {
        //   Task<GoalDTO> GetGoalById(Guid id); 
        //   Task<List<GoalDTO>> GetAllGoalsAsync();
        Task<List<GoalDTO>> GetGoalsByUserIdAsync(Guid userId); 
        Task<GoalDTO> CreateGoalAsync(GoalDTO goalDto);
        Task<bool> UpdateGoalAsync(Guid id, Goal updatedGoal);
        Task<bool> DeleteGoalAsync(Guid id);
    }
}
