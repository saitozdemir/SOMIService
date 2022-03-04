using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SOMIService.Migrations
{
    public partial class yenimig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FailureLoggings_Categories_CategoryId",
                table: "FailureLoggings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "FailureLoggingDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FailureLoggings",
                table: "FailureLoggings");

            migrationBuilder.DropIndex(
                name: "IX_FailureLoggings_CategoryId",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FailureLoggings");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "FailureLoggings",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "FailureLoggingId",
                table: "FailureLoggings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "FailureLoggings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TechnicianAssignDate",
                table: "FailureLoggings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianId",
                table: "FailureLoggings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TechnicianIsActive",
                table: "FailureLoggings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "FailureLoggings",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FailureLoggings",
                table: "FailureLoggings",
                column: "FailureLoggingId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FailureLoggings_AspNetUsers_TechnicianId",
                table: "FailureLoggings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FailureLoggings",
                table: "FailureLoggings");

            migrationBuilder.DropIndex(
                name: "IX_FailureLoggings_TechnicianId",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "FailureLoggingId",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "TechnicianAssignDate",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "TechnicianIsActive",
                table: "FailureLoggings");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "FailureLoggings");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "FailureLoggings",
                newName: "Location");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "FailureLoggings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "FailureLoggings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FailureLoggings",
                table: "FailureLoggings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FailureLoggingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailureLoggingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperatorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorIsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    OperatorProcessTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TechnicianId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicianReport = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureLoggingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FailureLoggingDetails_FailureLoggings_FailureLoggingId",
                        column: x => x.FailureLoggingId,
                        principalTable: "FailureLoggings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FailureLoggings_CategoryId",
                table: "FailureLoggings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FailureLoggingDetails_FailureLoggingId",
                table: "FailureLoggingDetails",
                column: "FailureLoggingId");

            migrationBuilder.AddForeignKey(
                name: "FK_FailureLoggings_Categories_CategoryId",
                table: "FailureLoggings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
