using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Email { get; set; }
        public  string Password { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<Workout> OwnedWorkouts { get; set; }
        public ICollection<UserWorkout> UserWorkouts { get; set; }
    }
}
