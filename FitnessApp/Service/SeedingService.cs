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

            if (!_context.Users.Any())
            {

                var users = new List<User>()
                {
                    new User { FirstName = "Мар'яна", LastName = "Хортюк", Email = "chucbki@gmail.com", Password = "12345Qwert" },
                    new User { FirstName = "Іванка", LastName = "Борд", Email = "ivanka@gmail.com", Password = "Qwert12345" }

                };
                _context.Users.AddRange(users);

                _context.SaveChanges();



                //var user = _context.Users.FirstOrDefault();
                //var workout = _context.Workouts.FirstOrDefault();


               






                if (!_context.Exercises.Any())
                {
                    var exercises = new List<Exercise>()
                    {
                        new Exercise { Name = "Присідання", Type = "Ноги", CaloriesLost = 100, Complexity = "Середній" },
                        new Exercise { Name = "Планка", Type = "Корпус", CaloriesLost = 50, Complexity = "Легкий" },
                        new Exercise { Name = "Віджимання", Type = "Руки", CaloriesLost = 80, Complexity = "Середній" },
                        new Exercise { Name = "Стрибки", Type = "Все тіло", CaloriesLost = 90, Complexity = "Середній" }

                    };
                    _context.Exercises.AddRange(exercises);

                    var workouts = new List<Workout>()
                    {
                        new Workout { Name = "Тренування 1", Date = new DateTime(2024, 04, 23) },
                        new Workout { Name = "Тренування 2", Date = new DateTime(2024, 04, 23) },
                        new Workout { Name = "Тренування 3", Date = new DateTime(2024, 04, 23) },
                        new Workout { Name = "Тренування 4", Date = new DateTime(2024, 03, 01) },
                        new Workout { Name = "Тренування користувача", Date = new DateTime(2024, 04, 23), Owner = users[0]  },
                        new Workout { Name = "Тренування користувача 2 ", Date = new DateTime(2024, 03, 07), Owner = users[0]  }


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
                        new ExerciseWorkout { Exercise = exercises[0], Workout = workouts[4], Count = 3, Time = 10, Order = 4 },
                        new ExerciseWorkout { Exercise = exercises[0], Workout = workouts[5], Count = 7, Time = 10, Order = 4 },

                    };
                        _context.ExerciseWorkouts.AddRange(exerciseWorkouts);

                        _context.SaveChanges();



                    var userWorkout = new List<UserWorkout>()
                    {
                      new UserWorkout() { UserId= _context.Users.FirstOrDefault(u => u.FirstName == "Мар'яна").Id,  Workout = workouts[5]},
                      new UserWorkout() { UserId= _context.Users.FirstOrDefault(u => u.FirstName == "Мар'яна").Id,  Workout = workouts[4]},
                       new UserWorkout() { UserId= _context.Users.FirstOrDefault(u => u.FirstName == "Мар'яна").Id,  Workout = workouts[0]},
                    };
                    _context.UserWorkouts.AddRange(userWorkout);

                    _context.SaveChanges();




                    //}

                    var user = _context.Users.FirstOrDefault(u => u.FirstName == "Мар'яна");

                    if (user != null)
                    {
                        var exercisesToAdd = new Dictionary<string, int>
                    {
                        { "Присідання", 100 },
                        { "Віджимання", 50 },
                        { "Планка", 60 } 
                    };

                        foreach (var kvp in exercisesToAdd)
                        {
                            var exerciseName = kvp.Key;
                            var count = kvp.Value;

                            var exercise = _context.Exercises.FirstOrDefault(e => e.Name == exerciseName);

                            if (exercise != null)
                            {
                                var goal = new Goal
                                {
                                    Description = $"Ціль зробити вправу '{exerciseName}'",
                                    Count = count,
                                    UserId = user.Id,
                                    ExerciseId = exercise.Id
                                };

                                _context.Goals.Add(goal);
                            }
                        }

                        _context.SaveChanges();
                    }

                }

            }
        }
    }
}


