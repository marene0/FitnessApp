using FitnessApp.Model;
using FitnessApp.Data;
using Microsoft.EntityFrameworkCore;


namespace FitnessApp.Data
{
    public class SeedingService
    {
        private readonly DataContext _context;

        public SeedingService(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        { 
            
            
                var users = new List<User>()
                {
                    new User { FirstName = "Мар'яна", LastName = "Хортюк", Email = "chucbki@gmail.com", Password = "12345Qwert" },
                    new User { FirstName = "Іванка", LastName = "Борд", Email = "ivanka@gmail.com", Password = "Qwert12345" }

                };
                _context.Users.AddRange(users);

                _context.SaveChanges();



             var user = _context.Users.FirstOrDefault();
             var workout = _context.Workouts.FirstOrDefault();


           // var UserWorkout = new UserWorkout { UserId = user.Id, WorkoutId = workout.Id };

            







            if (!_context.Exercises.Any())
            {
                var exercises = new List<Exercise>()
                {
                    new Exercise { Name = "Присідання", Type = "Ноги", CaloriesLost = 100, Complexity = "Середній" },
                    new Exercise { Name = "Планка", Type = "Корпус", CaloriesLost = 50, Complexity = "Легкий" },
                    new Exercise { Name = "Віджимання", Type = "Руки", CaloriesLost = 80, Complexity = "Середній" },
                    new Exercise { Name = "Планка", Type = "Все тіло", CaloriesLost = 90, Complexity = "Середній" }

                };
                _context.Exercises.AddRange(exercises);

                var workouts = new List<Workout>()
                {
                    new Workout { Name = "Тренування 1", Date = new DateTime(2024, 04, 23) },
                    new Workout { Name = "Тренування 2", Date = new DateTime(2024, 04, 23) },
                    new Workout { Name = "Тренування 3", Date = new DateTime(2024, 04, 23) },
                    new Workout { Name = "Тренування 4", Date = new DateTime(2024, 03, 01) },
                    new Workout { Name = "Тренування користувача", Date = new DateTime(2024, 04, 23), Owner = users[0]  }

                };
                _context.Workouts.AddRange(workouts);

                var exerciseWorkouts = new List<ExerciseWorkout>()
                {
                    new ExerciseWorkout { Exercise = exercises[0], Workout = workouts[0], Count = 3, Time = 10, Order = 1 },
                    new ExerciseWorkout { Exercise = exercises[1], Workout = workouts[0], Count = 3, Time = 10, Order = 2 },
                    new ExerciseWorkout { Exercise = exercises[1], Workout = workouts[1], Count = 3, Time = 10, Order = 2 },
                    new ExerciseWorkout { Exercise = exercises[2], Workout = workouts[1], Count = 3, Time = 10, Order = 3 },
                    new ExerciseWorkout { Exercise = exercises[3], Workout = workouts[1], Count = 3, Time = 10, Order = 4 },
                    new ExerciseWorkout { Exercise = exercises[1], Workout = workouts[3], Count = 3, Time = 10, Order = 2 },
                    new ExerciseWorkout { Exercise = exercises[3], Workout = workouts[4], Count = 3, Time = 10, Order = 4 },
                };
                _context.ExerciseWorkouts.AddRange(exerciseWorkouts);

                _context.SaveChanges();
            }
        }
    }
}








