using Microsoft.AspNetCore.Identity;

namespace Usuarios.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {

        public DateTime DataNascimento { get; set; }
    }
}
