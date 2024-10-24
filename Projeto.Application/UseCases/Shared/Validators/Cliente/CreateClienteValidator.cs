

using FluentValidation;
using Projeto.Application.UseCases.Cliente.Create;

namespace Projeto.Application.UseCases.Shared.Validators.Cliente
{
    public sealed class CreateClienteValidator : AbstractValidator<CreateClienteRequest>
    {
        public CreateClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(50).WithMessage("Minimo de 50 caracteres");
        }
    }
}
