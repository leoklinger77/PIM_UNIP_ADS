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
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.NomeCompleto)
                .NotEmpty()
                .WithMessage("O campo Nome Completo é obrigatório.");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("O campo Cpf é obrigatório.");

            RuleFor(x => x.Cpf.CpfValido())
                .Equal(true)
                .WithMessage("O Cpf informado é inválido.");
        }
    }
}
