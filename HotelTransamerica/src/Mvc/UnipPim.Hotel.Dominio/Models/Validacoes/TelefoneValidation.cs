using FluentValidation;
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class TelefoneValidation : AbstractValidator<Telefone>
    {
        public TelefoneValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.Ddd)
                .NotEmpty()
                .WithMessage("O campo Ddd é obrigatório.");

            RuleFor(x => x.Numero)
               .NotEmpty()
               .WithMessage("O campo Numero é obrigatório.");

            RuleFor(x => ExtensionsMethods.ValidaTipoEnum<TelefoneTipo>((int)x.TelefoneTipo))
                .Equal(true)
                .WithMessage("O campo Telefone Tipo informado é inválido.");
        }
    }
}
