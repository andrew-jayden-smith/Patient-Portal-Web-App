﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientPortalWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove the following line to prevent dropping the Role column (since it's already removed manually)
            // migrationBuilder.DropColumn(
            //     name: "Role",
            //     table: "Patients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // If needed, you can add code here to revert any changes made in the Up method.
        }
    }
}
