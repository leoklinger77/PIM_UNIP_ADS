using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class GrupoFuncionarioValidation : AbstractValidator<GrupoFuncionario>
    {
        public GrupoFuncionarioValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo Endereco de e-mail é obrigatório.")
                .Length(1, 50).WithMessage("O campo Número precisa ter entre 1 e 50 caracteres");
        }
    }
}
