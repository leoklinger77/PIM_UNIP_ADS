using System;
using System.Collections.Generic;
using System.Linq;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Frigobar : Entity, IAggregateRoot
    {
        //public Quarto Quarto { get; set; }
        //public Guid QuartoId { get; set; }

        private List<ProdutosFrigobar> _produtosFrigobar = new List<ProdutosFrigobar>();
        private List<ProdutosConsumidos> _produtosConsumido = new List<ProdutosConsumidos>();
        public int Quantidade { get; private set; }
        public decimal ValorTotalProdutos { get; private set; }

        
        public IReadOnlyCollection<ProdutosFrigobar> ProdutosFrigobar => _produtosFrigobar;
        public IReadOnlyCollection<ProdutosConsumidos> ProdutosConsumido => _produtosConsumido;

        protected Frigobar() { }

        public Frigobar(List<ProdutosFrigobar> produtosFrigobars)
        {
            _produtosFrigobar = produtosFrigobars;
            CalcularFrigobar();
        }

        public void AddProdutoFrigobar(ProdutosFrigobar produtos)
        {
            _produtosFrigobar.Add(produtos);
            CalcularFrigobar();

        }

        public void AddProdutoConsumido(ProdutosConsumidos produtos)
        {
            _produtosConsumido.Add(produtos);
            CalcularFrigobar();
        }

        private void CalcularFrigobar()
        {
            Quantidade = _produtosFrigobar.Count;
            ValorTotalProdutos = _produtosFrigobar.Sum(x => x.Total());
        }
    }

    public class ProdutosConsumidos : Entity
    {
        public Guid FrigobarId { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public decimal Valor { get; set; }
        public int Quantity { get; set; }
        public Frigobar Frigobar { get; set; }
        protected ProdutosConsumidos() { }

        public ProdutosConsumidos(Guid frigobarId, Produto produto, decimal valor, int quantity)
        {
            FrigobarId = frigobarId;
            Produto = produto;
            ProdutoId = produto.Id;
            Valor = valor;
            Quantity = quantity;
        }

        public decimal Total()
        {
            return Valor * Quantity;
        }
    }

    public class ProdutosFrigobar : Entity
    {
        public Guid FrigobarId { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public decimal Valor { get; set; }
        public int Quantity { get; set; }
        public Frigobar Frigobar { get; set; }

        protected ProdutosFrigobar() { }

        public ProdutosFrigobar(Guid frigobarId, Produto produto, decimal valor, int quantity)
        {
            FrigobarId = frigobarId;            
            ProdutoId = produto.Id;
            Valor = valor;
            Quantity = quantity;
        }

        public decimal Total()
        {
            return Valor * Quantity;
        }
    }
}
