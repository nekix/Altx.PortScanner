using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altx.PortScanner.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScanTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CompletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    HostName = table.Column<string>(type: "text", nullable: false),
                    EndPort = table.Column<int>(type: "integer", nullable: false),
                    ScanTypes = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScanResult",
                columns: table => new
                {
                    ScanTaskId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ports = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanResult", x => x.ScanTaskId);
                    table.ForeignKey(
                        name: "FK_ScanResult_ScanTasks_ScanTaskId",
                        column: x => x.ScanTaskId,
                        principalTable: "ScanTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScanResult");

            migrationBuilder.DropTable(
                name: "ScanTasks");
        }
    }
}
