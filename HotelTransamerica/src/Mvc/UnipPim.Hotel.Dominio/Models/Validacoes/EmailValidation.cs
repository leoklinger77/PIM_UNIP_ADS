using FluentValidation;
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo {PropertyName} é inválido.");

            RuleFor(x => x.EnderecoEmail)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(x => ExtensionsMethods.ValidaTipoEnum<EmailTipo>((int)x.EmailTipo))
                .NotEqual(true)
                .WithMessage("O campo {PropertyName} informado é inválido.");
        }
    }
}
