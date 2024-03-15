using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Exercise: BaseEntity
    {
        public string Type { get; set; }

        public string Name { get; set; }
        public int CaloriesLost { get; set; }
        public string Complexity { get; set; }
        public ICollection<ExerciseWorkout> ExerciseWorkouts { get; set; }
        public ICollection<Goal> Goals { get; set; }
    }
}