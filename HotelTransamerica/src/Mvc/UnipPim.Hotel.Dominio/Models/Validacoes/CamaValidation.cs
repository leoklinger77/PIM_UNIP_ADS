using FluentValidation;
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class CamaValidation : AbstractValidator<Cama>
    {
        public CamaValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => ExtensionsMethods.ValidaTipoEnum<CamaTipo>((int)x.CamaTipo))
                .Equal(true)
                .WithMessage("O campo CamaTipo é obrigatório.");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("O campo Quantidade deve ser maior que 0.");
        }
    }
}
