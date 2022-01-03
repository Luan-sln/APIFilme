using System.ComponentModel.DataAnnotations;

namespace FilmesLista.Data.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório!")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Não pode passar de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A Duração precisa ser entre 01 e 600 minutos")]
        public int Duracao { get; set; }
        public int ClassificaEtaria { get; set; }
    }
}
