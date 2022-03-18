using System.ComponentModel.DataAnnotations;

namespace FilmesLista.Data.Dtos
{
    public class ReadFilmeDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int ClassificaEtaria {get; set; }
        public DateTime HoraConsulta { get; set; }
    }
}
