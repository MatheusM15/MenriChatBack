using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraMenriChat.Migrations
{
    public partial class AdicionandoUsuarionaMenssagemUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioRemetenteId",
                table: "MenssageChatUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MenssageChatUsers_UsuarioId",
                table: "MenssageChatUsers",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MenssageChatUsers_UsuarioRemetenteId",
                table: "MenssageChatUsers",
                column: "UsuarioRemetenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenssageChatUsers_AspNetUsers_UsuarioId",
                table: "MenssageChatUsers",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenssageChatUsers_AspNetUsers_UsuarioRemetenteId",
                table: "MenssageChatUsers",
                column: "UsuarioRemetenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenssageChatUsers_AspNetUsers_UsuarioId",
                table: "MenssageChatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MenssageChatUsers_AspNetUsers_UsuarioRemetenteId",
                table: "MenssageChatUsers");

            migrationBuilder.DropIndex(
                name: "IX_MenssageChatUsers_UsuarioId",
                table: "MenssageChatUsers");

            migrationBuilder.DropIndex(
                name: "IX_MenssageChatUsers_UsuarioRemetenteId",
                table: "MenssageChatUsers");

            migrationBuilder.DropColumn(
                name: "UsuarioRemetenteId",
                table: "MenssageChatUsers");
        }
    }
}
