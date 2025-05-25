using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pin.LiveSports.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerTournament",
                keyColumns: new[] { "PlayersId", "TournamentsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PlayerTournament",
                keyColumns: new[] { "PlayersId", "TournamentsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PlayerTournament",
                keyColumns: new[] { "PlayersId", "TournamentsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PlayerTournament",
                keyColumns: new[] { "PlayersId", "TournamentsId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "PlayerTournament",
                keyColumns: new[] { "PlayersId", "TournamentsId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EventType", "MatchId", "PlayerId", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Lin Shidong scoorde een punt", 1, 1, 1, new DateTime(2025, 5, 14, 10, 37, 52, 300, DateTimeKind.Utc).AddTicks(181) },
                    { 2, "Hugo Calderano scoorde een punt", 1, 2, 3, new DateTime(2025, 5, 14, 10, 37, 52, 300, DateTimeKind.Utc).AddTicks(184) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_MatchId",
                table: "Events",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlayerId",
                table: "Events",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.InsertData(
                table: "PlayerTournament",
                columns: new[] { "PlayersId", "TournamentsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 1 }
                });
        }
    }
}
