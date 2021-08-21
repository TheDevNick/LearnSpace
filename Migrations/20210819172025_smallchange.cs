using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSpace.Migrations
{
    public partial class smallchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Accomplishments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Accomplishments");
        }
    }
}
