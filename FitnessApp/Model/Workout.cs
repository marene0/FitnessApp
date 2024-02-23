using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }
        public User Users { get; set; }
        public DateTime Date { get; set; }
        // public ICollection<Exercise> Exercises { get; set; }
        public ICollection<ExercisesWorkout> ExercisesWorkout { get; set; }

    }
}