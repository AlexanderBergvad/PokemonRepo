using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonRepo.Domain.Migrations
{
    public partial class chatroomAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_AspNetUsers_UserId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_ChatRoom_ChatRoomId",
                table: "ChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoom_AspNetUsers_UserId",
                table: "ChatRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoom",
                table: "ChatRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage");

            migrationBuilder.RenameTable(
                name: "ChatRoom",
                newName: "ChatRooms");

            migrationBuilder.RenameTable(
                name: "ChatMessage",
                newName: "ChatMessages");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoom_UserId",
                table: "ChatRooms",
                newName: "IX_ChatRooms_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_UserId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_ChatRoomId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRooms",
                table: "ChatRooms",
                column: "ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                column: "ChatMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserId",
                table: "ChatMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_ChatRooms_ChatRoomId",
                table: "ChatMessages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "ChatRoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_AspNetUsers_UserId",
                table: "ChatRooms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_ChatRooms_ChatRoomId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_AspNetUsers_UserId",
                table: "ChatRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRooms",
                table: "ChatRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "ChatRooms",
                newName: "ChatRoom");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "ChatMessage");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRooms_UserId",
                table: "ChatRoom",
                newName: "IX_ChatRoom_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessage",
                newName: "IX_ChatMessage_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ChatRoomId",
                table: "ChatMessage",
                newName: "IX_ChatMessage_ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoom",
                table: "ChatRoom",
                column: "ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage",
                column: "ChatMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_AspNetUsers_UserId",
                table: "ChatMessage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_ChatRoom_ChatRoomId",
                table: "ChatMessage",
                column: "ChatRoomId",
                principalTable: "ChatRoom",
                principalColumn: "ChatRoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoom_AspNetUsers_UserId",
                table: "ChatRoom",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
