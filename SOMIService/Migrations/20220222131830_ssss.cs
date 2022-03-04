

using Microsoft.EntityFrameworkCore.Migrations;

namespace SOMIService.Migrations
{
    public partial class ssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FailureLoggings_AspNetUsers_TechnicianId",
                table: "FailureLoggings");

            migrationBuilder.DropIndex(
                name: "IX_FailureLoggings_TechnicianId",
                table: "FailureLoggings");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicianId",
                table: "FailureLoggings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TechnicianId",
                table: "FailureLoggings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FailureLoggings_TechnicianId",
                table: "FailureLoggings",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_FailureLoggings_AspNetUsers_TechnicianId",
                table: "FailureLoggings",
                column: "TechnicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
