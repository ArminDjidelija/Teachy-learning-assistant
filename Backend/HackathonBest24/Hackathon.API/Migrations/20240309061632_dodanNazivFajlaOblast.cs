using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.API.Migrations
{
    /// <inheritdoc />
    public partial class dodanNazivFajlaOblast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NazivFajla",
                table: "Oblast",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazivFajla",
                table: "Oblast");
        }
    }
}
