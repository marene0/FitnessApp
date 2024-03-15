using FitnessApp.Model;

namespace FitnessApp.DTO
{
    public class GoalDTO : BaseEntity
    {
        public string Description { get; set; }
        public int Count { get; set; }
        public Guid UserId { get; set; } 
        public Guid ExerciseId { get; set; }
    }
}
