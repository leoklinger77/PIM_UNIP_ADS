using System;
using System.Collections.Generic;
using System.Text;
using UnipPim.Hotel.Dominio.Models.Enum;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Email : Entity
    {
        public string EnderecoEmail { get; private set; }
        public EmailTipo EmailTipo { get; private set; }

        public Funcionario Funcionario { get; set; }
        public Guid? FuncionarioId { get; set; }

        protected Email() { }

        public Email(string enderecoEmail, EmailTipo emailTipo)
        {
            EnderecoEmail = enderecoEmail;
            EmailTipo = emailTipo;
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            Funcionario = funcionario;
            FuncionarioId = funcionario.Id;
        }
    }
}
