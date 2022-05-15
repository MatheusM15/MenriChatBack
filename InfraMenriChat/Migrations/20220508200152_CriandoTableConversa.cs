using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraMenriChat.Migrations
{
    public partial class CriandoTableConversa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenssageChatUsers_AspNetUsers_UsuarioId",
                table: "MenssageChatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MenssageChatUsers_AspNetUsers_UsuarioRemetenteId",
                table: "MenssageChatUsers");

            migrationBuilder.RenameColumn(
                name: "UsuarioRemetenteId",
                table: "MenssageChatUsers",
                newName: "UsuarioEnvioId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "MenssageChatUsers",
                newName: "ConversaId");

            migrationBuilder.RenameIndex(
                name: "IX_MenssageChatUsers_UsuarioRemetenteId",
                table: "MenssageChatUsers",
                newName: "IX_MenssageChatUsers_UsuarioEnvioId");

            migrationBuilder.RenameIndex(
                name: "IX_MenssageChatUsers_UsuarioId",
                table: "MenssageChatUsers",
                newName: "IX_MenssageChatUsers_ConversaId");

            migrationBuilder.CreateTable(
                name: "Conversa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioPrimarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioSecundarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageChatUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversa_AspNetUsers_UsuarioPrimarioId",
                        column: x => x.UsuarioPrimarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversa_AspNetUsers_UsuarioSecundarioId",
                        column: x => x.UsuarioSecundarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversa_MenssageChatUsers_MessageChatUserId",
                        column: x => x.MessageChatUserId,
                        principalTable: "MenssageChatUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_MessageChatUserId",
                table: "Conversa",
                column: "MessageChatUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_UsuarioPrimarioId",
                table: "Conversa",
                column: "UsuarioPrimarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversa_UsuarioSecundarioId",
                table: "Conversa",
                column: "UsuarioSecundarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenssageChatUsers_AspNetUsers_UsuarioEnvioId",
                table: "MenssageChatUsers",
                column: "UsuarioEnvioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenssageChatUsers_Conversa_ConversaId",
                table: "MenssageChatUsers",
                column: "ConversaId",
                principalTable: "Conversa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenssageChatUsers_AspNetUsers_UsuarioEnvioId",
                table: "MenssageChatUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MenssageChatUsers_Conversa_ConversaId",
                table: "MenssageChatUsers");

            migrationBuilder.DropTable(
                name: "Conversa");

            migrationBuilder.RenameColumn(
                name: "UsuarioEnvioId",
                table: "MenssageChatUsers",
                newName: "UsuarioRemetenteId");

            migrationBuilder.RenameColumn(
                name: "ConversaId",
                table: "MenssageChatUsers",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_MenssageChatUsers_UsuarioEnvioId",
                table: "MenssageChatUsers",
                newName: "IX_MenssageChatUsers_UsuarioRemetenteId");

            migrationBuilder.RenameIndex(
                name: "IX_MenssageChatUsers_ConversaId",
                table: "MenssageChatUsers",
                newName: "IX_MenssageChatUsers_UsuarioId");

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
    }
}
