using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SOMIService.Migrations
{
    public partial class Guncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperationStatus",
                table: "FailureLoggings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OperationTime",
                table: "FailureLoggings",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationStatus",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "OperationTime",
                table: "FailureLoggings");
        }
    }
}
