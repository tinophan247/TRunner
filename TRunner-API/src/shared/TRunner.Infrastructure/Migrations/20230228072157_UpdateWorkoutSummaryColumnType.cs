using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRunner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkoutSummaryColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "WorkoutSummary",
                type: "char(20)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "WorkoutSummary",
                type: "char(20)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "WorkoutSummary",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(20)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "WorkoutSummary",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(20)");
        }
    }
}
