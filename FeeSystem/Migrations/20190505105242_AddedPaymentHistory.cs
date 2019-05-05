using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FeeSystem.Migrations
{
    public partial class AddedPaymentHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColdWaterConsumption",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "HotWaterConsumption",
                table: "Residents");

            migrationBuilder.CreateTable(
                name: "PricesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Changed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricesHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConnectedResidentId = table.Column<int>(nullable: true),
                    Month = table.Column<DateTime>(nullable: false),
                    PricesId = table.Column<int>(nullable: true),
                    HotWaterConsumption = table.Column<int>(nullable: false),
                    ColdWaterConsumption = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentHistories_Residents_ConnectedResidentId",
                        column: x => x.ConnectedResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentHistories_PricesHistory_PricesId",
                        column: x => x.PricesId,
                        principalTable: "PricesHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_ConnectedResidentId",
                table: "PaymentHistories",
                column: "ConnectedResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_PricesId",
                table: "PaymentHistories",
                column: "PricesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentHistories");

            migrationBuilder.DropTable(
                name: "PricesHistory");

            migrationBuilder.AddColumn<int>(
                name: "ColdWaterConsumption",
                table: "Residents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotWaterConsumption",
                table: "Residents",
                nullable: false,
                defaultValue: 0);
        }
    }
}
