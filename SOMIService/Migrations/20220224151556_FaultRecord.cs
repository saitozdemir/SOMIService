using Microsoft.EntityFrameworkCore.Migrations;

namespace SOMIService.Migrations
{
    public partial class FaultRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FaultIsFixxed",
                table: "FailureLoggings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OperatorId",
                table: "FailureLoggings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaultIsFixxed",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "FailureLoggings");
        }
    }
}
