using Microsoft.EntityFrameworkCore.Migrations;

namespace FeeSystem.Migrations
{
    public partial class AddedPayerNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayerNumber",
                table: "Residents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayerNumber",
                table: "Residents");
        }
    }
}
