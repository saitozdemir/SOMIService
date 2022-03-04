using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SOMIService.Migrations
{
    public partial class MİG3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FailureLoggings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureLoggings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FailureLoggings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FailureLoggings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FailureLoggingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FailureLoggingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorProcessTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperatorIsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    OperatorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicianId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicianReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_FailureLoggingDetails_FailureLoggingId",
                table: "FailureLoggingDetails",
                column: "FailureLoggingId");

            migrationBuilder.CreateIndex(
                name: "IX_FailureLoggings_CategoryId",
                table: "FailureLoggings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FailureLoggings_UserId",
                table: "FailureLoggings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FailureLoggingDetails");

            migrationBuilder.DropTable(
                name: "FailureLoggings");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
