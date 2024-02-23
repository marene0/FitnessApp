using FitnessApp.Data;
using FitnessApp.Interfaces;
using FitnessApp.Model;

namespace FitnessApp.Repository
{
    public class ExerciseRepository : IExerciseRepository 
    {
        private readonly DataContext _context;

        public ExerciseRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Exercise>GetExercises()
        {
            return _context.Exercises.OrderBy(e => e.ExerciseId).ToList();
        }
    }
}
