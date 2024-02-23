using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutAdminSets",
                columns: table => new
                {
                    WorkoutAdminSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutAdminSets", x => x.WorkoutAdminSetId);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.WorkoutId);
                    table.ForeignKey(
                        name: "FK_Workouts_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseWorkoutAdminSets",
                columns: table => new
                {
                    ExerciseWorkoutAdminSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutAdminSetsWorkoutAdminSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWorkoutAdminSets", x => x.ExerciseWorkoutAdminSetId);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkoutAdminSets_WorkoutAdminSets_WorkoutAdminSetsWorkoutAdminSetId",
                        column: x => x.WorkoutAdminSetsWorkoutAdminSetId,
                        principalTable: "WorkoutAdminSets",
                        principalColumn: "WorkoutAdminSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExercisesWorkouts",
                columns: table => new
                {
                    ExercisesWorkoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesWorkouts", x => x.ExercisesWorkoutId);
                    table.ForeignKey(
                        name: "FK_ExercisesWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    CaloriesLost = table.Column<int>(type: "int", nullable: false),
                    Complexity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExercisesWorkoutId = table.Column<int>(type: "int", nullable: false),
                    ExerciseWorkoutAdminSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseWorkoutAdminSets_ExerciseWorkoutAdminSetId",
                        column: x => x.ExerciseWorkoutAdminSetId,
                        principalTable: "ExerciseWorkoutAdminSets",
                        principalColumn: "ExerciseWorkoutAdminSetId");
                    table.ForeignKey(
                        name: "FK_Exercises_ExercisesWorkouts_ExercisesWorkoutId",
                        column: x => x.ExercisesWorkoutId,
                        principalTable: "ExercisesWorkouts",
                        principalColumn: "ExercisesWorkoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExercisesExerciseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalsId);
                    table.ForeignKey(
                        name: "FK_Goals_Exercises_ExercisesExerciseId",
                        column: x => x.ExercisesExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExercisesWorkoutId",
                table: "Exercises",
                column: "ExercisesWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseWorkoutAdminSetId",
                table: "Exercises",
                column: "ExerciseWorkoutAdminSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesWorkouts_WorkoutId",
                table: "ExercisesWorkouts",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkoutAdminSets_WorkoutAdminSetsWorkoutAdminSetId",
                table: "ExerciseWorkoutAdminSets",
                column: "WorkoutAdminSetsWorkoutAdminSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ExercisesExerciseId",
                table: "Goals",
                column: "ExercisesExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserId",
                table: "Goals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UsersUserId",
                table: "Workouts",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseWorkoutAdminSets");

            migrationBuilder.DropTable(
                name: "ExercisesWorkouts");

            migrationBuilder.DropTable(
                name: "WorkoutAdminSets");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
