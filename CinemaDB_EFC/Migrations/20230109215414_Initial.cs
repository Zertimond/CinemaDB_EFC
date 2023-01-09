using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaDBEFC.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    CinemaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Filmax"),
                    WorkerAmmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.CinemaID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    FilmType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Actors = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Anagraph = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FilmID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    WorkerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.WorkerID);
                    table.UniqueConstraint("AK_Person_FirstName_LastName_MiddleName", x => new { x.FirstName, x.LastName, x.MiddleName });
                });

            migrationBuilder.CreateTable(
                name: "Hall",
                columns: table => new
                {
                    HallID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaID = table.Column<int>(type: "int", nullable: false),
                    HallNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Schedule = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FilmList = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Placeammount = table.Column<int>(name: "Place_ammount", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hall", x => x.HallID);
                    table.ForeignKey(
                        name: "FK_Hall_Cinema_CinemaID",
                        column: x => x.CinemaID,
                        principalTable: "Cinema",
                        principalColumn: "CinemaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    WorkerID = table.Column<int>(type: "int", nullable: false),
                    CinemaID = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    IDcard = table.Column<int>(type: "int", nullable: true),
                    NumberID = table.Column<int>(type: "int", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.WorkerID);
                    table.ForeignKey(
                        name: "FK_Worker_Cinema_CinemaID",
                        column: x => x.CinemaID,
                        principalTable: "Cinema",
                        principalColumn: "CinemaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worker_Person_WorkerID",
                        column: x => x.WorkerID,
                        principalTable: "Person",
                        principalColumn: "WorkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    ShowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    HallID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "date", nullable: false),
                    Boughttickets = table.Column<int>(name: "Bought_tickets", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.ShowID);
                    table.ForeignKey(
                        name: "FK_Show_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Show_Hall_HallID",
                        column: x => x.HallID,
                        principalTable: "Hall",
                        principalColumn: "HallID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowID = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ticket__712CC6273EA99273", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Ticket_Show_ShowID",
                        column: x => x.ShowID,
                        principalTable: "Show",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hall_CinemaID",
                table: "Hall",
                column: "CinemaID");

            migrationBuilder.CreateIndex(
                name: "IX_Show_FilmID",
                table: "Show",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Show_HallID",
                table: "Show",
                column: "HallID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ShowID",
                table: "Ticket",
                column: "ShowID");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_CinemaID",
                table: "Worker",
                column: "CinemaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Show");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Hall");

            migrationBuilder.DropTable(
                name: "Cinema");
        }
    }
}
