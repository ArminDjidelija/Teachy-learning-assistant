using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.API.Migrations
{
    /// <inheritdoc />
    public partial class druga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RazredId",
                table: "Test",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Test_RazredId",
                table: "Test",
                column: "RazredId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Razred_RazredId",
                table: "Test",
                column: "RazredId",
                principalTable: "Razred",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Razred_RazredId",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_RazredId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "RazredId",
                table: "Test");
        }
    }
}
