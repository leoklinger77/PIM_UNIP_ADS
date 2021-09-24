using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class FotoValidation : AbstractValidator<Foto>
    {
        public FotoValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");

            RuleFor(x => x.Caminho)
                .NotEmpty()
                .WithMessage("O campo Caminho é obrigatório.");                
        }
    }
}
