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
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.EnderecoEmail)
                .NotEmpty()
                .WithMessage("O campo Endereco de e-mail é obrigatório.");

            RuleFor(x => ExtensionsMethods.ValidaTipoEnum<EmailTipo>((int)x.EmailTipo))
                .Equal(true)
                .WithMessage("O campo Tipo Email informado é inválido.");
        }
    }
}
