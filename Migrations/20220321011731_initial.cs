using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CC.Scheduling.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SchedulingDB");

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "SchedulingDB",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "SchedulingDB",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    FromTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ToTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedule_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "SchedulingDB",
                        principalTable: "Client",
                        principalColumn: "ClientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClientId",
                schema: "SchedulingDB",
                table: "Schedule",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "SchedulingDB");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "SchedulingDB");
        }
    }
}
