using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.CidadeId)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo CidadeId é inválido.");

            RuleFor(x => x.Cep)
                .NotEmpty()
                .WithMessage("O campo Cep é obrigatório.")
                .Length(8, 8).WithMessage("O campo Cep precisa ter entre 8 caracteres");

            RuleFor(x => x.Numero)
               .NotEmpty()
               .WithMessage("O campo Numero é obrigatório.")
               .Length(1, 50).WithMessage("O campo Número precisa ter entre 1 e 50 caracteres");            

            RuleFor(x => x.Complemento)
               .NotEmpty()
               .WithMessage("O campo Complemento é obrigatório.")
               .Length(1, 100).WithMessage("O campo Número precisa ter entre 1 e 100 caracteres");

            RuleFor(x => x.Bairro)
               .NotEmpty()
               .WithMessage("O campo Bairro é obrigatório.")
               .Length(1, 100).WithMessage("O campo Bairro precisa ter entre 1 e 100 caracteres");
        }
    }
}
