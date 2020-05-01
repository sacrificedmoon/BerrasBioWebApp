using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerrasBioWebApp.Migrations
{
    public partial class AddDbContextToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Length = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Seats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filmid = table.Column<int>(nullable: false),
                    Salonid = table.Column<int>(nullable: false),
                    ShowTime = table.Column<DateTime>(nullable: false),
                    FreeChairs = table.Column<int>(nullable: false),
                    IsFullyBooked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmSchedule_Film_Filmid",
                        column: x => x.Filmid,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmSchedule_Salon_Salonid",
                        column: x => x.Salonid,
                        principalTable: "Salon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmScheduleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    NumOfTickets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_FilmSchedule_FilmScheduleId",
                        column: x => x.FilmScheduleId,
                        principalTable: "FilmSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FilmScheduleId",
                table: "Booking",
                column: "FilmScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSchedule_Filmid",
                table: "FilmSchedule",
                column: "Filmid");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSchedule_Salonid",
                table: "FilmSchedule",
                column: "Salonid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "FilmSchedule");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Salon");
        }
    }
}
