using FilmesLista.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesLista.Data.Dtos
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
