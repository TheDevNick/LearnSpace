using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSpace.Migrations
{
    public partial class LearnSpaceModifiedUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accomplishments_UserId",
                table: "Accomplishments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accomplishments_Users_UserId",
                table: "Accomplishments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accomplishments_Users_UserId",
                table: "Accomplishments");

            migrationBuilder.DropIndex(
                name: "IX_Accomplishments_UserId",
                table: "Accomplishments");
        }
    }
}
