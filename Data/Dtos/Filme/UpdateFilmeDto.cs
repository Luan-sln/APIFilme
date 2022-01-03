using System.ComponentModel.DataAnnotations;

namespace FilmesLista.Data.Dtos
{
    public class UpdateFilmeDto
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int ClassificaEtaria { get; set; }
    }
}
