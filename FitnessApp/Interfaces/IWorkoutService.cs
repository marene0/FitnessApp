using FitnessApp.DTO;
using FitnessApp.Model;
using FitnessApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Interfaces
{
    public interface IWorkoutService
    {
       
       // Workout GetWorkoutById(Guid id);
        Task<WorkoutDTO> CreateWorkoutAsync(WorkoutDTO workoutDto);
        Task<WorkoutDTO> UpdateWorkoutAsync(Guid id, WorkoutDTO updatedWorkoutDto);
        Task<bool> DeleteWorkoutAsync(Guid id);
        Task<List<Workout>> GetAllWorkoutsAsync();
        Task<List<Workout>> GetAllWorkoutsAsync(Guid userId);
        Task<WorkoutDTO> GetWorkoutByIdAsync(Guid id);
   
    }
}
