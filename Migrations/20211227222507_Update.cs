using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesLista.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoFK",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "GerenteFK",
                table: "Cinemas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoFK",
                table: "Cinemas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GerenteFK",
                table: "Cinemas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
