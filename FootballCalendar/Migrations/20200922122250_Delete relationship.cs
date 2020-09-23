using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballСalendar.Migrations
{
    public partial class Deleterelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFootballGames_tblHomeTeams_HomeTeamId",
                table: "tblFootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFootballGames_tblOpponentTeams_OpponentTeamId",
                table: "tblFootballGames");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tblOpponentTeams_FootballGameId",
                table: "tblOpponentTeams");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tblHomeTeams_FootballGameId",
                table: "tblHomeTeams");

            migrationBuilder.AlterColumn<long>(
                name: "FootballGameId",
                table: "tblOpponentTeams",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "FootballGameId",
                table: "tblHomeTeams",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFootballGames_tblHomeTeams_HomeTeamId",
                table: "tblFootballGames",
                column: "HomeTeamId",
                principalTable: "tblHomeTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFootballGames_tblOpponentTeams_OpponentTeamId",
                table: "tblFootballGames",
                column: "OpponentTeamId",
                principalTable: "tblOpponentTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFootballGames_tblHomeTeams_HomeTeamId",
                table: "tblFootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFootballGames_tblOpponentTeams_OpponentTeamId",
                table: "tblFootballGames");

            migrationBuilder.AlterColumn<long>(
                name: "FootballGameId",
                table: "tblOpponentTeams",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FootballGameId",
                table: "tblHomeTeams",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tblOpponentTeams_FootballGameId",
                table: "tblOpponentTeams",
                column: "FootballGameId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tblHomeTeams_FootballGameId",
                table: "tblHomeTeams",
                column: "FootballGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFootballGames_tblHomeTeams_HomeTeamId",
                table: "tblFootballGames",
                column: "HomeTeamId",
                principalTable: "tblHomeTeams",
                principalColumn: "FootballGameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFootballGames_tblOpponentTeams_OpponentTeamId",
                table: "tblFootballGames",
                column: "OpponentTeamId",
                principalTable: "tblOpponentTeams",
                principalColumn: "FootballGameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
