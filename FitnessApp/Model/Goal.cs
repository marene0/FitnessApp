using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Model
{
    public class Goal : BaseEntity
    {
        public string Description { get; set; }
        public Exercise Exercise { get; set; }
        public Guid UserId { get; set; }
        public Guid ExerciseId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
    }
}
