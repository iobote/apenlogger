using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestLoggerMvc.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Executed = table.Column<DateTime>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    ActionType = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Actor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Executed = table.Column<DateTime>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    ActionType = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    LogLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "ItemVersions");

            migrationBuilder.DropTable(
                name: "SystemLogs");
        }
    }
}
