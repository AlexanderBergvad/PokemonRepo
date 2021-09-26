using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonRepo.Domain.Migrations
{
    public partial class ChangedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_UserId",
                table: "ChatRooms");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ChatRooms",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_UserId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_OwnerId",
                table: "ChatRooms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_OwnerId",
                table: "ChatRooms");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "ChatRooms",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_OwnerId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_UserId",
                table: "ChatRooms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
