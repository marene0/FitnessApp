using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class ExercisesWorkout
    {
        [Key]
        public int ExercisesWorkoutId { get; set; }
        public Workout Workout { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public int Count { get; set; }
    }
}
