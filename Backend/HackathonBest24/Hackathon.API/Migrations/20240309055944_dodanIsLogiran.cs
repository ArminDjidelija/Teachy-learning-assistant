using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.API.Migrations
{
    /// <inheritdoc />
    public partial class dodanIsLogiran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Logiran",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Logiran",
                table: "Profesor",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logiran",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Logiran",
                table: "Profesor");
        }
    }
}
