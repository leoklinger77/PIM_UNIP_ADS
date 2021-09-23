using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class AcessoValidation : AbstractValidator<Acesso>
    {
        public AcessoValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.ClaimType)
                .NotEmpty()
                .WithMessage("O campo ClaimType é obrigatório.")
                .Length(1, 50).WithMessage("O campo ClaimType precisa ter entre 1 e 50 caracteres");
            
            RuleFor(x => x.ClaimValue)
                .NotEmpty()
                .WithMessage("O campo ClaimValue é obrigatório.")
                .Length(1, 100).WithMessage("O campo ClaimValue precisa ter entre 1 e 50 caracteres");
        }
    }
}
