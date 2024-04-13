using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientPortalWebApp.Migrations
{
    /// <inheritdoc />
    public partial class SpecificDateandTimeseperated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "AppointmentTime",
                table: "Bookings",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<DateOnly>(
                name: "AppointmentDate",
                table: "Bookings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDate",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AppointmentTime",
                table: "Bookings",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)");
        }
    }
}
