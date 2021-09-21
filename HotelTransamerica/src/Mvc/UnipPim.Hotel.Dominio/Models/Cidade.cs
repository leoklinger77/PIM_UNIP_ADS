using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Cidade : Entity
    {
        public string Nome { get; private set; }
        public Estado Estado { get; private set; }
        public Guid EstadoId { get; private set; }

        private List<Endereco> _enderecos = new List<Endereco>();
        public IReadOnlyCollection<Endereco> Enderecos => _enderecos;

        protected Cidade() { }
        public Cidade(string nome, Estado estado)
        {
            Nome = nome;
            Estado = estado;
            EstadoId = estado.Id;
        }
    }
}
