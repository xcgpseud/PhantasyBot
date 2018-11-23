using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhantasyBot.Migrations
{
    public partial class AddLoggingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandLogs",
                columns: table => new
                {
                    CommandLogId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommandName = table.Column<string>(nullable: false),
                    CommandParams = table.Column<string>(nullable: true),
                    UserId = table.Column<ulong>(nullable: false),
                    UserDisplayName = table.Column<string>(nullable: false),
                    CommandTimestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandLogs", x => x.CommandLogId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandLogs");
        }
    }
}
