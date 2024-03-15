using Microsoft.EntityFrameworkCore;
using FitnessApp.Data;
using FitnessApp.Model;
using FitnessApp.Interfaces;
using FitnessApp.DTO;
using System.Security.Authentication;

namespace FitnessApp.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly DataContext _context;

        public WorkoutService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Workout>> GetAllWorkoutsAsync()
        {
            return await _context.Workouts.ToListAsync();
        }

        //public async Task<WorkoutDTO> GetWorkoutByIdAsync(Guid id)
        //{
        //    return await _context.Workouts.FindAsync(id);
        //}

        public async Task<WorkoutDTO> GetWorkoutByIdAsync(Guid id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return null;
            }

            var workoutDto = new WorkoutDTO
            {
                Name = workout.Name,
                Date = workout.Date,
                OwnerId = workout.OwnerId
            };

            return workoutDto;
        }

        public async Task<WorkoutDTO> CreateWorkoutAsync(WorkoutDTO workoutDto)
        {
            if (workoutDto.OwnerId.HasValue) 
            {
                var userExists = await _context.Users
                    .AnyAsync(t => t.Id == workoutDto.OwnerId.Value);

                if (!userExists)
                {
                    throw new AuthenticationException();
                }
            }

            var exerciseIds = workoutDto.Exercises.Select(t => t.ExerciseId);

            var exercises = await _context.Exercises
                .Where(t => exerciseIds.Contains(t.Id))
                .ToListAsync();

            var id = Guid.NewGuid();
            var workout = new Workout
            {
                Id = id,
                Name = workoutDto.Name,
                Date = DateTime.Now,
                OwnerId = workoutDto.OwnerId,
                ExerciseWorkouts = exercises.Select(t => new ExerciseWorkout 
                { 
                    WorkoutId = id,
                    ExerciseId = t.Id
                }).ToList()
            };
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return workoutDto;
        }

        public async Task<WorkoutDTO> UpdateWorkoutAsync(Guid id, WorkoutDTO updatedWorkoutDto)
        {
            var workoutDto = await _context.Workouts.FindAsync(id);
            if (workoutDto == null)
            {
                return null;
            }

            workoutDto.Name = updatedWorkoutDto.Name;
            workoutDto.Date = updatedWorkoutDto.Date;
            workoutDto.OwnerId = updatedWorkoutDto.OwnerId;

            await _context.SaveChangesAsync();
            return updatedWorkoutDto;
        }

        public async Task<bool> DeleteWorkoutAsync(Guid id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return false;
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return true;
        }

        //public List<Workout> GetAllWorkouts()
        //{
        //    throw new NotImplementedException();
        //}

       

        //public async Task<bool> CreateWorkout(Workout workout)
        //{
        //    try
        //    {
        //        _context.Workouts.Add(workout);
        //        await _context.SaveChangesAsync();
        //        return true; 
        //    }
        //    catch (Exception)
        //    {
        //        return false; 
        //    }
        //}

        public async Task<List<Workout>> GetAllWorkoutsAsync(Guid userId)
        {
            return await _context.Workouts.Where(s => s.OwnerId == null || s.OwnerId == userId).ToListAsync();
        }
    }
}

