using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraMenriChat.Migrations
{
    public partial class RemovendoMenssagemUsersConversa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversa_MenssageChatUsers_MessageChatUserId",
                table: "Conversa");

            migrationBuilder.DropIndex(
                name: "IX_Conversa_MessageChatUserId",
                table: "Conversa");

            migrationBuilder.DropColumn(
                name: "MessageChatUserId",
                table: "Conversa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MessageChatUserId",
                table: "Conversa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_MessageChatUserId",
                table: "Conversa",
                column: "MessageChatUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversa_MenssageChatUsers_MessageChatUserId",
                table: "Conversa",
                column: "MessageChatUserId",
                principalTable: "MenssageChatUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
