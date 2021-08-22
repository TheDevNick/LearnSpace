using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSpace.Migrations
{
    public partial class ModifiedAccomplishments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigWin",
                table: "Accomplishments");

            migrationBuilder.DropColumn(
                name: "SmallWin",
                table: "Accomplishments");

            migrationBuilder.AddColumn<string>(
                name: "AccomplishmentDescription",
                table: "Accomplishments",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "AccomplishmentName",
                table: "Accomplishments",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "AccomplishmentType",
                table: "Accomplishments",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccomplishmentDescription",
                table: "Accomplishments");

            migrationBuilder.DropColumn(
                name: "AccomplishmentName",
                table: "Accomplishments");

            migrationBuilder.DropColumn(
                name: "AccomplishmentType",
                table: "Accomplishments");

            migrationBuilder.AddColumn<string>(
                name: "BigWin",
                table: "Accomplishments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SmallWin",
                table: "Accomplishments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");
        }
    }
}
