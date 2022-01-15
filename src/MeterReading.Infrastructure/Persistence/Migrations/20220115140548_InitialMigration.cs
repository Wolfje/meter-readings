using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeterReading.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MeterReadings");

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "MeterReadings",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                schema: "MeterReadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadingValue = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readings_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "MeterReadings",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Readings_AccountId",
                schema: "MeterReadings",
                table: "Readings",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Readings",
                schema: "MeterReadings");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "MeterReadings");
        }
    }
}
