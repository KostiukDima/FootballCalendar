using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballСalendar.Migrations
{
    public partial class AddLogoFC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "tblFootballClubs",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "tblFootballClubs");
        }
    }
}
