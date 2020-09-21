using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballСalendar.Migrations
{
    public partial class AddFlagContry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Flag",
                table: "tblCountries",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flag",
                table: "tblCountries");
        }
    }
}
