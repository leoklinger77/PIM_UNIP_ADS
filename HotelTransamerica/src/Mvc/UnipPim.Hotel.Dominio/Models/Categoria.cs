using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Categoria : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        private List<Produto> _produtos = new List<Produto>();
        public IReadOnlyCollection<Produto> Produtos => _produtos;

        protected Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
        }

        public void SetNome(string value)
        {
            Nome = value;
        }
    }
}
