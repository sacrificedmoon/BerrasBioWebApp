using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BerrasBioWebApp.Migrations
{
    public partial class AddedDbContextToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    year = table.Column<int>(nullable: false),
                    length = table.Column<TimeSpan>(type: "time(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    seats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FilmSchedule",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filmid = table.Column<int>(nullable: false),
                    salonid = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    showtime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    freechairs = table.Column<int>(nullable: false),
                    fullybooked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmSchedule", x => x.id);
                    table.ForeignKey(
                        name: "FK__FilmSched__filmi__3F466844",
                        column: x => x.filmid,
                        principalTable: "Film",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__FilmSched__salon__403A8C7D",
                        column: x => x.salonid,
                        principalTable: "Salon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmSchedule_filmid",
                table: "FilmSchedule",
                column: "filmid");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSchedule_salonid",
                table: "FilmSchedule",
                column: "salonid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmSchedule");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Salon");
        }
    }
}
