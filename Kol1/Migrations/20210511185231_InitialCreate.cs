using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kol1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    IdChampionship = table.Column<int>(type: "int", nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.IdChampionship);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.IdPlayer);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "Championship_Team",
                columns: table => new
                {
                    IdChampionshipTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChampionship = table.Column<int>(type: "int", nullable: false),
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship_Team", x => x.IdChampionshipTeam);
                    table.ForeignKey(
                        name: "FK_Championship_Team_Championship_IdChampionship",
                        column: x => x.IdChampionship,
                        principalTable: "Championship",
                        principalColumn: "IdChampionship",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Championship_Team_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player_Team",
                columns: table => new
                {
                    IdPlayerTeam = table.Column<int>(type: "int", nullable: false),
                    IdPlayer = table.Column<int>(type: "int", nullable: false),
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    NumOnShirt = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Team", x => x.IdPlayerTeam);
                    table.ForeignKey(
                        name: "FK_Player_Team_Player_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Player",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Team_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Championship",
                columns: new[] { "IdChampionship", "OfficialName", "Year" },
                values: new object[,]
                {
                    { 1, "Name1", 2000 },
                    { 2, "Name2", 2001 },
                    { 3, "Name3", 2002 },
                    { 4, "Name4", 2003 },
                    { 5, "Name5", 2004 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "IdPlayer", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 11, 20, 52, 30, 824, DateTimeKind.Local).AddTicks(8746), "Jan", "Dobusz" },
                    { 2, new DateTime(2021, 5, 11, 20, 52, 30, 828, DateTimeKind.Local).AddTicks(7551), "Barby", "Girl" },
                    { 3, new DateTime(2021, 5, 11, 20, 52, 30, 828, DateTimeKind.Local).AddTicks(7597), "Diana", "Kathe" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "IdTeam", "MaxAge", "TeamName" },
                values: new object[,]
                {
                    { 1, 23, "Dinamo" },
                    { 2, 25, "Shahter" },
                    { 3, 30, "Team3" }
                });

            migrationBuilder.InsertData(
                table: "Championship_Team",
                columns: new[] { "IdChampionshipTeam", "IdChampionship", "IdTeam", "Score" },
                values: new object[,]
                {
                    { 1, 2, 1, 1f },
                    { 2, 1, 2, 1.1f },
                    { 5, 1, 2, 3f },
                    { 3, 3, 3, 1.2f },
                    { 4, 3, 3, 2f }
                });

            migrationBuilder.InsertData(
                table: "Player_Team",
                columns: new[] { "IdPlayerTeam", "Comment", "IdPlayer", "IdTeam", "NumOnShirt" },
                values: new object[,]
                {
                    { 2, "Comment1", 3, 1, 122 },
                    { 5, "Comment1", 1, 1, 111 },
                    { 1, "Comment1", 1, 2, 101 },
                    { 4, "Comment1", 3, 2, 512 },
                    { 3, "Comment1", 2, 3, 421 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Team_IdChampionship",
                table: "Championship_Team",
                column: "IdChampionship");

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Team_IdTeam",
                table: "Championship_Team",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Team_IdPlayer",
                table: "Player_Team",
                column: "IdPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Team_IdTeam",
                table: "Player_Team",
                column: "IdTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Championship_Team");

            migrationBuilder.DropTable(
                name: "Player_Team");

            migrationBuilder.DropTable(
                name: "Championship");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
