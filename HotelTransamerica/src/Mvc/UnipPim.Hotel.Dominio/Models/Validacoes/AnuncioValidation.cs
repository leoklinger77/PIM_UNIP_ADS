using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class AnuncioValidation : AbstractValidator<Anuncio>
    {
        public AnuncioValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo ClaimType é obrigatório.")
                .Length(1, 50).WithMessage("O campo ClaimType precisa ter entre 1 e 50 caracteres");            
        }
    }
}
