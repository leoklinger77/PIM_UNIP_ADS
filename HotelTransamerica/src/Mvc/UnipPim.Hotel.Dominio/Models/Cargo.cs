using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Cargo : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        private List<Funcionario> _funcionarios = new List<Funcionario>();
        public IReadOnlyCollection<Funcionario> Funcionarios => _funcionarios;
        protected Cargo() { }

        public Cargo(string nome)
        {
            Nome = nome;
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            _funcionarios.Add(funcionario);
        }
        
    }
}
