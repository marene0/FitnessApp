using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserWorkoutKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkouts",
                table: "UserWorkouts");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserWorkouts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkouts",
                table: "UserWorkouts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_WorkoutId",
                table: "UserWorkouts",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkouts",
                table: "UserWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkouts_WorkoutId",
                table: "UserWorkouts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserWorkouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkouts",
                table: "UserWorkouts",
                columns: new[] { "WorkoutId", "UserId" });
        }
    }
}
