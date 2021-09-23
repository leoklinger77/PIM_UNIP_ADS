using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class GrupoFuncionario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        private List<Funcionario> _funcionarios = new List<Funcionario>();
        public IReadOnlyCollection<Funcionario> Funcionarios => _funcionarios;

        private List<Acesso> _acesso = new List<Acesso>();
        public IReadOnlyCollection<Acesso> Acesso => _acesso;

        protected GrupoFuncionario() { }

        public GrupoFuncionario(string nome)
        {
            Nome = nome;
        }       
    }

    public class Acesso : Entity
    {
        public string ClaimType { get; private set; }
        public string ClaimValue { get; private set; }

        protected Acesso() { }

        public Acesso(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        internal void SetClaimType(string claimType)
        {
            ClaimType = claimType;
        }

        internal void SetClaimValue(string claimValue)
        {
            ClaimValue = claimValue;
        }
    }
}
