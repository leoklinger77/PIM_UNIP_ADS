using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.CategoriaId)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo CategoriaId é inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo ClaimType é obrigatório.")
                .Length(1, 50).WithMessage("O campo ClaimType precisa ter entre 1 e 50 caracteres");

            RuleFor(x => x.CodigoBarras)
                .NotEmpty()
                .WithMessage("O campo ClaimType é obrigatório.")
                .Length(13, 14).WithMessage("O campo ClaimType precisa ter entre 13 e 14 caracteres");

            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("O campo valor não pode ser 0.");
        }
    }
}
