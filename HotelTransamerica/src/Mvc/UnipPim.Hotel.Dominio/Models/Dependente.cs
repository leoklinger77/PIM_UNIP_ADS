using System;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Dependente : Entity
    {
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public DateTime Nascimento { get; private set; }

        public Hospede Responsabel { get; private set; }
        public Guid ResponsavelId { get; private set; }

        protected Dependente() { }

        public Dependente(string nomeCompleto, string cpf, DateTime nascimento, Guid responsavelId)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            Nascimento = nascimento;
            ResponsavelId = responsavelId;
        }
    }
}
