using System.ComponentModel.DataAnnotations;
using FilmesLista.Models;

namespace FilmesLista.Data
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Gerente Gerente{ get; set; }
    }
}
