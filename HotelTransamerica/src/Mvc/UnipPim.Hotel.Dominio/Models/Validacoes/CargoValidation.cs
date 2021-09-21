using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class CargoValidation : AbstractValidator<Cargo>
    {
        public CargoValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo {PropertyName} é inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
