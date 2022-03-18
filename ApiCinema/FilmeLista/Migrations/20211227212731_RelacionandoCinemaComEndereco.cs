using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesLista.Migrations
{
    public partial class RelacionandoCinemaComEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoID",
                table: "Cinemas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_EnderecoID",
                table: "Cinemas",
                column: "EnderecoID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoID",
                table: "Cinemas",
                column: "EnderecoID",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoID",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_EnderecoID",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "EnderecoID",
                table: "Cinemas");
        }
    }
}
