using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesLista.Migrations
{
    public partial class RelacionamentoGerente_Cinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GerenteID",
                table: "Cinemas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_GerenteID",
                table: "Cinemas",
                column: "GerenteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteID",
                table: "Cinemas",
                column: "GerenteID",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteID",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_GerenteID",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "GerenteID",
                table: "Cinemas");
        }
    }
}
