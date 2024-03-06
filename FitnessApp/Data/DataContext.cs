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
        public DataContext()
        {
            
        }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseWorkout> ExerciseWorkouts { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<UserWorkout> UserWorkouts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                  .HasMany(ew => ew.ExerciseWorkouts)
                  .WithOne(e => e.Exercise)
                  .HasForeignKey(t => t.ExerciseId);

            modelBuilder.Entity<Workout>()
                  .HasMany(ew => ew.ExerciseWorkouts)
                  .WithOne(w => w.Workout)
                  .HasForeignKey(w => w.WorkoutId);

            modelBuilder.Entity<Workout>()
                  .HasMany(uw => uw.UserWorkouts)
                  .WithOne(w => w.Workout)
                  .HasForeignKey(w => w.WorkoutId);

           

            modelBuilder.Entity<Goal>() 
              .HasOne(e => e.Exercise)
              .WithMany(g => g.Goals)
              .HasForeignKey(e => e.ExerciseId);

            modelBuilder.Entity<Goal>()
               .HasOne(u => u.User)
               .WithMany(g => g.Goals)
               .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<User>()
                 .HasMany(uw => uw.UserWorkouts)
                 .WithOne(u => u.User)
                 .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<User>()
                .HasMany(uw => uw.OwnedWorkouts)
                .WithOne(u => u.Owner)
                .HasForeignKey(x => x.OwnerId);


            modelBuilder.Entity<ExerciseWorkout>()
                .HasKey(e => new { e.WorkoutId, e.ExerciseId });

            modelBuilder.Entity<UserWorkout>()
                .HasKey(e => new { e.WorkoutId, e.UserId });
        }

    }
}
