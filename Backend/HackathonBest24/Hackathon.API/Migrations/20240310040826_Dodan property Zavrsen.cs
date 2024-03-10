using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.API.Migrations
{
    /// <inheritdoc />
    public partial class DodanpropertyZavrsen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Zavrsen",
                table: "Test",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zavrsen",
                table: "Test");
        }
    }
}
