using System;
using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Anuncio : Entity, IAggregateRoot
    {
        public Guid FuncionarioId { get; private set; }
        public Guid QuartoId { get; private set; }
        public bool Ativo { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Custo { get; private set; }

        public Funcionario Funcionario { get; private set; }
        public Quarto Quarto { get; private set; }

        private List<Foto> _Fotos = new List<Foto>();
        public IReadOnlyCollection<Foto> Fotos => _Fotos;

        public Anuncio() { }

        public Anuncio(bool ativo, int quantidade, decimal custo)
        {
            Ativo = ativo;
            Quantidade = quantidade;
            Custo = custo;
        }

        public void AddFoto(Foto fotos)
        {
            _Fotos.Add(fotos);
        }
    }
}
