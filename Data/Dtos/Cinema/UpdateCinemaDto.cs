using System.ComponentModel.DataAnnotations;

namespace FilmesLista.Data
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}
