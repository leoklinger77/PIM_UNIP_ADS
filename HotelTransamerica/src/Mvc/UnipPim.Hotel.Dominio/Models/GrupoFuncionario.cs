using System;
using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class GrupoFuncionario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        private List<Funcionario> _funcionarios = new List<Funcionario>();
        public IReadOnlyCollection<Funcionario> Funcionarios => _funcionarios;

        private HashSet<Acesso> _acesso = new HashSet<Acesso>();
        public IReadOnlyCollection<Acesso> Acesso => _acesso;

        protected GrupoFuncionario() { }

        public GrupoFuncionario(string nome)
        {
            Nome = nome;
        }      
        
        public void AddAcesso(Acesso acesso)
        {
            _acesso.Add(acesso);
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

        public override bool Equals(object obj)
        {
            return obj is Acesso acesso &&
                   ClaimType == acesso.ClaimType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ClaimType);
        }
    }
}
