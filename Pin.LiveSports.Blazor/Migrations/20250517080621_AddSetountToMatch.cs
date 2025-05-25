using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pin.LiveSports.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class AddSetountToMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "CurrentSet",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player1Score",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player1Sets",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player2Score",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player2Sets",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrentSet", "Player1Score", "Player1Sets", "Player2Score", "Player2Sets", "TafelTennisZaal" },
                values: new object[] { 1, 0, 0, 0, 0, "Amsterdam '78" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CurrentSet", "Player1Score", "Player1Sets", "Player2Score", "Player2Sets", "TafelTennisZaal" },
                values: new object[] { 1, 0, 0, 0, 0, "Amsterdam '78" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentSet",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Player1Score",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Player1Sets",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Player2Score",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Player2Sets",
                table: "Matches");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "TafelTennisZaal",
                value: "Tafeltennisvereniging Amsterdam '78 – Baarsjesweg 265 H, 1058 AC Amsterdam");

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                column: "TafelTennisZaal",
                value: "Tafeltennisvereniging Amsterdam '78 – Baarsjesweg 265 H, 1058 AC Amsterdam");

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Player1Id", "Player2Id", "StartTime", "Status", "TafelTennisZaal", "TournamentId" },
                values: new object[,]
                {
                    { 3, 1, 3, new DateTime(2023, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), "Gepland", "Tafeltennisvereniging Rotterdam '78 – Baarsjesweg 265 H, 1058 AC Rotterdam", 2 },
                    { 4, 2, 4, new DateTime(2023, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "Gepland", "Tafeltennisvereniging Rotterdam '78 – Baarsjesweg 265 H, 1058 AC Rotterdam", 2 },
                    { 5, 1, 4, new DateTime(2023, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), "Gepland", "Tafeltennisvereniging Tokyo '78 – Baarsjesweg 265 H, 1058 AC Tokyo", 3 }
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
    }
}
