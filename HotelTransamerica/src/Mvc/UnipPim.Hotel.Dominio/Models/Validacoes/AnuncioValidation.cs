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
                .WithMessage("O campo Nome é obrigatório.")
                .Length(10, 100).WithMessage("O campo Nome precisa ter entre 10 e 100 caracteres");            
        }
    }
}
