namespace FitnessApp.Model
{
    public class UserWorkout : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid WorkoutId { get; set; }
        public User User { get; set; }
        public Workout Workout { get; set; }
    }
}