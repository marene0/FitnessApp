using Microsoft.EntityFrameworkCore;
using FitnessApp.Data;
using FitnessApp.Model;
using FitnessApp.Interfaces;
using FitnessApp.DTO;

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

        public async Task<Workout> GetWorkoutByIdAsync(Guid id)
        {
            return await _context.Workouts.FindAsync(id);
        }

        public async Task<WorkoutDTO> CreateWorkoutAsync(WorkoutDTO workoutDto)
        {
            if (workoutDto.OwnerId.HasValue) 
            {
                var userExists = await _context.Users
                    .AnyAsync(t => t.Id == workoutDto.OwnerId.Value);

                if (!userExists)
                {
                    //throw exception
                    return null;
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

        public async Task<Workout> UpdateWorkoutAsync(Guid id, Workout updatedWorkout)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return null;
            }

            workout.Name = updatedWorkout.Name;
            workout.Date = updatedWorkout.Date;
            workout.OwnerId = updatedWorkout.OwnerId;

            await _context.SaveChangesAsync();
            return workout;
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

        public List<Workout> GetAllWorkouts()
        {
            throw new NotImplementedException();
        }

        public Workout GetWorkoutById(Guid id)
        {
            throw new NotImplementedException();
        }

       

        public async Task<bool> CreateWorkout(Workout workout)
        {
            try
            {
                _context.Workouts.Add(workout);
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception)
            {
                return false; 
            }
        }



        public async Task<List<Workout>> GetAllWorkoutsAsync(Guid userId)
        {
            return await _context.Workouts.Where(s => s.OwnerId == null || s.OwnerId == userId).ToListAsync();
        }
    }
}

