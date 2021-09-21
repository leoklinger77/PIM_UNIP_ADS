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
                .WithMessage("O campo {PropertyName} é inválido.");

            RuleFor(x => x.Ddd)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(x => x.Numero)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(x => ExtensionsMethods.ValidaTipoEnum<TelefoneTipo>((int)x.TelefoneTipo))
                .NotEqual(true)
                .WithMessage("O campo {PropertyName} informado é inválido.");
        }
    }
}
