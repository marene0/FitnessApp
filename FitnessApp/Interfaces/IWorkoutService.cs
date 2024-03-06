using FitnessApp.DTO;
using FitnessApp.Model;
using FitnessApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Interfaces
{
    public interface IWorkoutService
    {
       
        Workout GetWorkoutById(Guid id);
        Task<WorkoutDTO> CreateWorkoutAsync(WorkoutDTO workoutDto);
        Task<Workout> UpdateWorkoutAsync(Guid id, Workout updatedWorkout);
        Task<bool> DeleteWorkoutAsync(Guid id);
        Task<List<Workout>> GetAllWorkoutsAsync();
        Task<List<Workout>> GetAllWorkoutsAsync(Guid userId);
        Task<Workout> GetWorkoutByIdAsync(Guid id);
   
    }
}
