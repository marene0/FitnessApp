using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string Type { get; set; }
        public int Time { get; set; }
        public int CaloriesLost { get; set; }
        public string Complexity { get; set; }
        public ExercisesWorkout ExercisesWorkout { get; set; }
        public ICollection<Goals> Goals { get; set; }
    }
}
