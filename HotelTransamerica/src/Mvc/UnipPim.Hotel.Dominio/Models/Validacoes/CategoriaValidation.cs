using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        public CategoriaValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório.")
                .Length(1, 50).WithMessage("O campo Nome precisa ter entre 1 e 50 caracteres");
        }
    }
}
