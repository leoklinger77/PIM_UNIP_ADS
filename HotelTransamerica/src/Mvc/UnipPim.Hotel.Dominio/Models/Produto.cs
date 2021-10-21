using System;
using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Produto: Entity, IAggregateRoot
    {
        public Guid CategoriaId { get; private set; }
        
        public string Nome { get; private set; }
        public string CodigoBarras { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public int QuantidadeVendida { get; private set; }
        public decimal Valor { get; private set; }
        public Categoria Categoria { get; private set; }
        private List<ItensVenda> _itensVendas = new List<ItensVenda>();
        public IReadOnlyCollection<ItensVenda> ItensVendas => _itensVendas;

        protected Produto() { }

        public Produto(string nome, string codigoBarras, int quantidadeEstoque, decimal valor, Guid categoriaId)
        {
            Nome = nome;
            CodigoBarras = codigoBarras;
            QuantidadeEstoque = quantidadeEstoque;
            Valor = valor;
            CategoriaId = categoriaId;
        }

        public void DebitarEstoqueVenda(int value)
        {
            QuantidadeEstoque -= value;
            QuantidadeVendida += value;
        }

        public void SetNome(string value)
        {
            Nome = value;
        }

        public void SetCodigoBarras(string value)
        {
            CodigoBarras = value;
        }

        
    }
}
