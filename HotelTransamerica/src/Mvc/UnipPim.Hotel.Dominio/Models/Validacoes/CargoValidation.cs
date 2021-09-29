using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class CargoValidation : AbstractValidator<Cargo>
    {
        public CargoValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório.")
                .Length(2, 100).WithMessage("O campo Nome precisa ter entre 2 e 100 caracteres");
        }
    }
}
