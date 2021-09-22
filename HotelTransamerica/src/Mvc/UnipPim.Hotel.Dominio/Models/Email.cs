using System;
using UnipPim.Hotel.Dominio.Models.Enum;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Email : Entity
    {
        public string EnderecoEmail { get; private set; }
        public EmailTipo EmailTipo { get; private set; }

        public Funcionario Funcionario { get; private set; }
        public Guid? FuncionarioId { get; private set; }

        public Hospede Hospede { get; private set; }
        public Guid? HospedeId { get; private set; }

        protected Email() { }

        public Email(string enderecoEmail, EmailTipo emailTipo)
        {
            EnderecoEmail = enderecoEmail;
            EmailTipo = emailTipo;
        }
    }
}
