using Microsoft.EntityFrameworkCore.Migrations;

namespace InfraMenriChat.Migrations
{
    public partial class AdicionandoCampoFotoNoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AspNetUsers");
        }
    }
}
