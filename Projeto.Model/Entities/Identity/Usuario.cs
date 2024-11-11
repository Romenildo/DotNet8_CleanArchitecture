
using Microsoft.AspNetCore.Identity;

namespace Projeto.Model.Entities.Identity
{
    public class Usuario : IdentityUser
    {
        public string? Cpf { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
