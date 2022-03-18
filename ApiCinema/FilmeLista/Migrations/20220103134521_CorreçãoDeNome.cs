using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesLista.Migrations
{
    public partial class CorreçãoDeNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassficaEtaria",
                table: "Filmes",
                newName: "ClassificaEtaria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassificaEtaria",
                table: "Filmes",
                newName: "ClassficaEtaria");
        }
    }
}
