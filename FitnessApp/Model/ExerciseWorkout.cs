using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class ExerciseWorkout //: BaseEntity
    {
        public Workout Workout { get; set; }

        public Guid WorkoutId { get; set; }
        public Exercise Exercise { get; set; }
        public Guid ExerciseId { get; set; }
        public int Count { get; set; }
        public int Time { get; set; }
        public int Order { get; set; }
    }
}
