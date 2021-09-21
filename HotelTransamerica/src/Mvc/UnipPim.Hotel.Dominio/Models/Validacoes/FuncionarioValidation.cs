using FluentValidation;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class FuncionarioValidation : AbstractValidator<Funcionario>
    {
        public FuncionarioValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo {PropertyName} é inválido.");

            RuleFor(x => x.NomeCompleto)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(x => x.Cpf.CpfValido())
                .NotEqual(true)
                .WithMessage("O {PropertyName} informado é inválido.");
        }
    }
}
