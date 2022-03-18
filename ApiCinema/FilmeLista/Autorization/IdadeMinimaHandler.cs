

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FilmesLista.Autorization
{
    public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinimaRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                return Task.CompletedTask;
            }

            var dataNascimento = Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

            int idadeObt = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento>DateTime.Today.AddYears(-idadeObt))
            {
                idadeObt--;
            }

            if (idadeObt >= requirement.IdadeMinima) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
