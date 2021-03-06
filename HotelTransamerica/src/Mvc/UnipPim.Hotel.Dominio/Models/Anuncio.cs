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
        private List<Reserva> _reservas = new List<Reserva>();
        public IReadOnlyCollection<Foto> Fotos => _Fotos;
        public IReadOnlyCollection<Reserva> Reservas => _reservas;

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

        public Anuncio(Guid id, string nome, bool ativo, int quantidade, decimal custo, Guid funcionarioId, Guid quartoId)
        {
            Id = id;
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
            fotos.SetAnuncio(Id);
            _Fotos.Add(fotos);
        }

        public void RemoveFoto(Foto fotos)
        {
            _Fotos.Remove(fotos);
        }

        public void AtivarAnuncio()
        {
            Ativo = true;
        }
        public void DesativarAnuncio()
        {
            Ativo = false;
        }
        public void SetQuantidade(int value)
        {
            Quantidade = value;
        }
        public void SetCusto(decimal value)
        {
            Custo = value;
        }
        public void SetQuartoId(Guid value)
        {
            QuartoId = value;
        }
    }
}