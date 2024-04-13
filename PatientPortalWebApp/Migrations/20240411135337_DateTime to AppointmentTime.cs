using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientPortalWebApp.Migrations
{
    /// <inheritdoc />
    public partial class DateTimetoAppointmentTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AppointmentTime",
                table: "Bookings",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PatientId",
                table: "Bookings",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Patients_PatientId",
                table: "Bookings",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Patients_PatientId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PatientId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentTime",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
