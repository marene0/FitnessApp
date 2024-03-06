using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Workout : BaseEntity
    {
        public Guid? OwnerId { get; set; }
        public DateTime Date { get; set; }
        public User? Owner { get; set; }
        public string Name { get; set; }
        public  ICollection<ExerciseWorkout> ExerciseWorkouts { get; set; }
        public  ICollection<UserWorkout> UserWorkouts { get; set; }

    }
}