using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballСalendar.Migrations
{
    public partial class Updaderelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFootballClubs_tblCoaches_CoachId",
                table: "tblFootballClubs");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tblCoaches_FootballClubId",
                table: "tblCoaches");

            migrationBuilder.AlterColumn<long>(
                name: "FootballClubId",
                table: "tblCoaches",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFootballClubs_tblCoaches_CoachId",
                table: "tblFootballClubs",
                column: "CoachId",
                principalTable: "tblCoaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFootballClubs_tblCoaches_CoachId",
                table: "tblFootballClubs");

            migrationBuilder.AlterColumn<long>(
                name: "FootballClubId",
                table: "tblCoaches",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tblCoaches_FootballClubId",
                table: "tblCoaches",
                column: "FootballClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFootballClubs_tblCoaches_CoachId",
                table: "tblFootballClubs",
                column: "CoachId",
                principalTable: "tblCoaches",
                principalColumn: "FootballClubId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
