using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class ProdutosConsumidosValidation : AbstractValidator<ProdutosConsumidos>
    {
        public ProdutosConsumidosValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("A quantidade não pode ser igual a 0");

            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("O valor do produto não pode ser igual a 0");
        }
    }
}
