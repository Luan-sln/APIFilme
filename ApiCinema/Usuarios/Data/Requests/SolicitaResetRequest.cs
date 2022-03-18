using System.ComponentModel.DataAnnotations;

namespace Usuarios.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
