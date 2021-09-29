using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class QuartoValidation : AbstractValidator<Quarto>
    {
        public QuartoValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("O campo Descricao é obrigatório.")
                .Length(10, 255).WithMessage("O campo Descricao precisa ter entre 10 e 50 caracteres");
            
        }
    }
}
