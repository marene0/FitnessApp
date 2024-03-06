//using FitnessApp.Data;
//using FitnessApp.DTO;
//using FitnessApp.Interfaces;
//using FitnessApp.Model;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FitnessApp.Services
//{
//    public class GoalService : IGoalService
//    {
//        private readonly DataContext _context;

//        public GoalService(DataContext context)
//        {
//            _context = context;
//        }

//        public async Task<Goal> GetGoalByIdAsync(Guid id) // was int
//        {
//            return await _context.Goals.FindAsync(id);
//        }

//        public async Task<List<Goal>> GetAllGoalsAsync()
//        {
//            return await _context.Goals.ToListAsync();
//        }

//        public async Task<List<Goal>> GetGoalsByUserIdAsync(Guid userId) // in interface was "int"
//        {
//            return await _context.Goals.Where(s => s.UserId == null || s.UserId == userId).ToListAsync();
//        }


//        public async Task<Goal> CreateGoalAsync(Goal goal)
//        {
//            _context.Goals.Add(goal);
//            await _context.SaveChangesAsync();
//            return goal;
//        }

//        public async Task<bool> UpdateGoalAsync(Guid id, Goal updatedGoal) // was int 
//        {
//            var existingGoal = await _context.Goals.FindAsync(id);
//            if (existingGoal == null)
//                return false;

//            existingGoal.Description = updatedGoal.Description;
//            existingGoal.UserId = updatedGoal.UserId;
//            existingGoal.ExerciseId = updatedGoal.ExerciseId;

//            _context.Goals.Update(existingGoal);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> DeleteGoalAsync(Guid id) // also was int 
//        {
//            var goalToDelete = await _context.Goals.FindAsync(id);
//            if (goalToDelete == null)
//                return false;

//            _context.Goals.Remove(goalToDelete);
//            await _context.SaveChangesAsync();
//            return true;
//        }


//        public async Task<GoalDTO> CreateGoalAsync(GoalDTO goalDto)
//        {
//            var exerciseIds = goalDto.Exercises.Select(e => e.ExerciseId).Distinct();

//            if (exerciseIds.Count() != goalDto.Exercises.Count)
//            {
//                return null;
//            }

//            var exercises = new List<Exercise>();

//            foreach (var exerciseId in exerciseIds)
//            {
//                var exercise = await _context.Exercises.FindAsync(exerciseId);
//                if (exercise == null)
//                {
//                    return null;
//                }
//                exercises.Add(exercise);
//            }

//            var goal = new Goal
//            {
//                Description = goalDto.Description,
//                Count = goalDto.Count
//            };

//            foreach (var exercise in exercises)
//            {
//                goal.ExerciseWorkouts.Add(new ExerciseWorkout
//                {
//                    Exercise = exercise,
//                    Goal = goal
//                });
//            }


//            _context.Goals.Add(goal);
//            await _context.SaveChangesAsync();

//            return new GoalDTO
//            {
//                Description = goal.Description,
//                Count = goal.Count
//            };
//        }












//    }
//}
