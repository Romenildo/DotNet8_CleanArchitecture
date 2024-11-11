using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.UseCases.Shared.Dtos.Usuario
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "O campo Cpf é obrigatório.")]
        public string? Cpf { get; set; }
        [Required(ErrorMessage = "O campo Password é obrigatório.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string? Email { get; set; }
    }
}
