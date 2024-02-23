using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class ExerciseWorkoutAdminSet
    {
        [Key]
        public int ExerciseWorkoutAdminSetId { get; set; }
        public WorkoutAdminSet WorkoutAdminSets { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
