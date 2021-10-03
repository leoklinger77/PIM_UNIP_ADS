using FluentValidation;

namespace UnipPim.Hotel.Dominio.Models.Validacoes
{
    public class FrigobarValidation : AbstractValidator<Frigobar>
    {
        public FrigobarValidation()
        {
            RuleFor(x => x.Id)
                .NotEqual(System.Guid.Empty)
                .WithMessage("O campo Id é inválido.");            
        }
    }
}
