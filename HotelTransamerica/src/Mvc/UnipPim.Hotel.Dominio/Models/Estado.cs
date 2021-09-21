using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Estado : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public string Uf { get; set; }

        private List<Cidade> _cidades = new List<Cidade>();
        public IReadOnlyCollection<Cidade> Cidades => _cidades;

        public Estado() { }
        public Estado(string nome, string uf)
        {
            Nome = nome;
            Uf = uf;
        }
    }
}
