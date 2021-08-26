using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSpace.Migrations
{
    public partial class LearnSpaceAddLikesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccomplishmentId",
                table: "Likes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AccomplishmentId",
                table: "Likes",
                column: "AccomplishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Accomplishments_AccomplishmentId",
                table: "Likes",
                column: "AccomplishmentId",
                principalTable: "Accomplishments",
                principalColumn: "AccomplishmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Accomplishments_AccomplishmentId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_AccomplishmentId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "AccomplishmentId",
                table: "Likes");
        }
    }
}
