using FitnessApp.Data;
using FitnessApp.DTO;
using FitnessApp.Interfaces;
using FitnessApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FitnessApp.Services
{
    public class GoalService : IGoalService
    {
        private readonly DataContext _context;

        public GoalService(DataContext context)
        {
            _context = context;
        }


        public async Task<GoalDTO> CreateGoalAsync(GoalDTO goalDto)
        {
            try
            {

                var goal = new Goal
                {
                    Description = goalDto.Description,
                    Count = goalDto.Count,
                    UserId = goalDto.UserId,
                    ExerciseId = goalDto.ExerciseId
                };

                _context.Goals.Add(goal);
                await _context.SaveChangesAsync();

                var createdGoalDto = new GoalDTO
                {
                    Id = goal.Id,
                    Description = goal.Description,
                    Count = goal.Count,
                    UserId = goal.UserId,
                    ExerciseId = goal.ExerciseId,
                };

                return createdGoalDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<GoalDTO>> GetGoalsByUserIdAsync(Guid userId)
        {
            var goals = await _context.Goals
                .Where(g => g.UserId == userId)
                .ToListAsync();

            var goalDTOs = goals.Select(g => new GoalDTO
            {
                Id = g.Id,
                Description = g.Description,
                Count = g.Count
            }).ToList();

            return goalDTOs;
        }

        public async Task<bool> UpdateGoalAsync(Guid id, Goal updatedGoal)
        {
            var existingGoal = await _context.Goals.FindAsync(id);
            if (existingGoal == null)
                return false;

            existingGoal.Description = updatedGoal.Description;
            existingGoal.Count = updatedGoal.Count;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteGoalAsync(Guid id)
        {
            var goalToDelete = await _context.Goals.FindAsync(id);
            if (goalToDelete == null)
                return false;

            try
            {
                _context.Goals.Remove(goalToDelete);
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }



    }
}

