using Microsoft.EntityFrameworkCore.Migrations;

namespace FeeSystem.Migrations
{
    public partial class AddedPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CentralHeating",
                table: "PricesHistory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ColdWater",
                table: "PricesHistory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Exploitation",
                table: "PricesHistory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HotWater",
                table: "PricesHistory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Menagment",
                table: "PricesHistory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RepairFund",
                table: "PricesHistory",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Sewage",
                table: "PricesHistory",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CentralHeating",
                table: "PricesHistory");

            migrationBuilder.DropColumn(
                name: "ColdWater",
                table: "PricesHistory");

            migrationBuilder.DropColumn(
                name: "Exploitation",
                table: "PricesHistory");

            migrationBuilder.DropColumn(
                name: "HotWater",
                table: "PricesHistory");

            migrationBuilder.DropColumn(
                name: "Menagment",
                table: "PricesHistory");

            migrationBuilder.DropColumn(
                name: "RepairFund",
                table: "PricesHistory");

            migrationBuilder.DropColumn(
                name: "Sewage",
                table: "PricesHistory");
        }
    }
}
