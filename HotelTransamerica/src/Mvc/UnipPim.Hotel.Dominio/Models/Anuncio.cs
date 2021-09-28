using System;
using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Anuncio : Entity, IAggregateRoot
    {
        public Guid FuncionarioId { get; private set; }
        public Guid QuartoId { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Custo { get; private set; }
        public Funcionario Funcionario { get; private set; }
        public Quarto Quarto { get; private set; }

        private List<Foto> _Fotos = new List<Foto>();
        public IReadOnlyCollection<Foto> Fotos => _Fotos;

        protected Anuncio() { }

        public Anuncio(string nome, bool ativo, int quantidade, decimal custo, Guid funcionarioId, Guid quartoId)
        {
            Nome = nome;
            Ativo = ativo;
            Quantidade = quantidade;
            Custo = custo;
            FuncionarioId = funcionarioId;
            QuartoId = quartoId;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void AddFoto(Foto fotos)
        {
            _Fotos.Add(fotos);
        }
    }
}
