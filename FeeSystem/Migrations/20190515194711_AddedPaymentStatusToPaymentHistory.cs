using Microsoft.EntityFrameworkCore.Migrations;

namespace FeeSystem.Migrations
{
    public partial class AddedPaymentStatusToPaymentHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PaymentStatus",
                table: "PaymentHistories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "PaymentHistories");
        }
    }
}
