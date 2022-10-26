using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGo.Data.Migrations
{
    public partial class UpdatedGameController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Console",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Console",
                table: "Games");
        }
    }
}
