using FluentValidation;
using FluentValidation.Results;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public abstract class ServicoBase
    {
        protected readonly INotificacao _notifier;

        protected ServicoBase(INotificacao notifier)
        {
            _notifier = notifier;
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notifier.AddError(mensagem);
        }

        protected bool IniciarValidacao<Tv, Te>(Tv validacao, Te entidade) where Tv : AbstractValidator<Te> where Te : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
