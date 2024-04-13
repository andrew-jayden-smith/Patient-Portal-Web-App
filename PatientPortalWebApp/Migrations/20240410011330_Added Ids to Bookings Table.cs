using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientPortalWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdstoBookingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "CurrentPatientId",
            //    table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "CurrentPatientId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Bookings",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Bookings",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
