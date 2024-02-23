using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class WorkoutAdminSet
    {
        [Key]
        public int WorkoutAdminSetId { get; set; }
        public int SetName { get; set; }
        public ICollection<ExerciseWorkoutAdminSet> ExerciseWorkoutAdminSets { get; set; }
    }
}
