using System.ComponentModel.DataAnnotations;

namespace FilmesLista.Data
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoID { get; set; }
        public int GerenteID { get; set; }
    }
}
