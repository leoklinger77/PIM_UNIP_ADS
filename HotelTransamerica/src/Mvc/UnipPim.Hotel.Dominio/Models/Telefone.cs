using System;
using UnipPim.Hotel.Dominio.Models.Enum;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Telefone : Entity
    {
        public string Ddd { get; private set; }
        public string Numero { get; private set; }
        public TelefoneTipo TelefoneTipo { get; private set; }

        public Funcionario Funcionario { get; private set; }
        public Guid? FuncionarioId { get; private set; }
        protected Telefone() { }

        public Telefone(string ddd, string numero, TelefoneTipo telefoneTipo)
        {
            Ddd = ddd;
            Numero = numero;
            TelefoneTipo = telefoneTipo;
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            Funcionario = funcionario;
            FuncionarioId = funcionario.Id;
        }
    }
}
