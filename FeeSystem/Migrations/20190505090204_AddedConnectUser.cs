using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FeeSystem.Migrations
{
    public partial class AddedConnectUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConnectedUser",
                table: "Residents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectedUser",
                table: "Residents");
        }
    }
}
