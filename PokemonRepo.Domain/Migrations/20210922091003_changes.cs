using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonRepo.Domain.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PokedexId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PokedexId",
                table: "AspNetUsers",
                column: "PokedexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pokedexes_PokedexId",
                table: "AspNetUsers",
                column: "PokedexId",
                principalTable: "Pokedexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pokedexes_PokedexId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PokedexId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PokedexId",
                table: "AspNetUsers");
        }
    }
}
