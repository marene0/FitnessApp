using FitnessApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExercisesWorkout> ExercisesWorkouts { get; set; }
        public DbSet<ExerciseWorkoutAdminSet> ExerciseWorkoutAdminSets { get; set; }
        public DbSet<Goals> Goals { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutAdminSet> WorkoutAdminSets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExercisesWorkout>()
                  .HasMany(e => e.Exercises)
                  .WithOne(ew => ew.ExercisesWorkout);

            modelBuilder.Entity<Workout>()
                  .HasMany(ew => ew.ExercisesWorkout)
                  .WithOne(w => w.Workout);

            modelBuilder.Entity<WorkoutAdminSet>()
                .HasMany(a => a.ExerciseWorkoutAdminSets)
                .WithOne(wa => wa.WorkoutAdminSets);

            modelBuilder.Entity<Exercise>()
                .HasMany(g => g.Goals)
                .WithOne(e => e.Exercises);

            modelBuilder.Entity<Goals>()
               .HasOne(g => g.User)
               .WithMany(u => u.Goals)
               .HasForeignKey(g => g.UserId)
               .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<User>()
                .HasMany(w => w.Workouts)
                .WithOne(u => u.Users);
        }

    }
}
