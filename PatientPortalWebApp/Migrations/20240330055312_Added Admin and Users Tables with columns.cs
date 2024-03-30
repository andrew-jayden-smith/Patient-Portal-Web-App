using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientPortalWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdminandUsersTableswithcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Role",
            //    table: "Patients");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Doctors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Role",
            //    table: "Patients",
            //    type: "longtext",
            //    nullable: false)
            //    .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Patients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Doctors",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
