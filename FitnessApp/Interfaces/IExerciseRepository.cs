using FitnessApp.Model;

namespace FitnessApp.Interfaces
{
    public interface IExerciseRepository
    {
        ICollection<Exercise> GetExercises();
    }
}
