using FitnessApp.Model;

namespace FitnessApp.DTO
{
    public class WorkoutDTO
    {
        public Guid? OwnerId { get; set; }
        public required string Name { get; set; }
        public List<ExerciseWorkoutDto> Exercises { get; set; }
    }

    public class ExerciseWorkoutDto
    { 
        public int Order { get; set; }
        public Guid ExerciseId { get; set; }
    }
}
