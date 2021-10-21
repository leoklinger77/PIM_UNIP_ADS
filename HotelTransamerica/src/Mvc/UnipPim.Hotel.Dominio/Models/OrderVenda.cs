using System;
using System.Collections.Generic;
using System.Linq;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Models
{
    public class OrderVenda : Entity
    {
        public DateTime Instante { get; private set; }
        public string Cpf { get; private set; }
        public decimal ValorTotal { get; private set; }
        public int QuantidadeTotal { get; private set; }

        private List<ItensVenda> _itensVendas = new List<ItensVenda>();
        public IReadOnlyCollection<ItensVenda> ItensVendas => _itensVendas;

        protected OrderVenda() { }
        public OrderVenda(string cpf = null)
        {
            Cpf = cpf;
            Instante = DateTime.Now;
        }

        public void AddItem(ItensVenda itensVenda)
        {
            var item = _itensVendas.Where(x => x.ProdutoId == itensVenda.ProdutoId).FirstOrDefault();
            if (item != null)
            {
                if(item.PrecoVenda != itensVenda.PrecoVenda)
                {
                    item.SetPreco(itensVenda.PrecoVenda);
                }
                item.AddQuantidade(itensVenda.Quantidade);
            }
            else
            {
                _itensVendas.Add(itensVenda);
            }
            
            Calcula();
        }

        public void RemoveItem(ItensVenda itensVenda)
        {
            var item = _itensVendas.Where(x => x.ProdutoId == itensVenda.ProdutoId).FirstOrDefault();
            if (item == null)
            {
                throw new DomainException("Produto não encontrado");
            }
            _itensVendas.Remove(itensVenda);
        }

        private void Calcula()
        {
            ValorTotal = _itensVendas.Sum(x => x.PrecoVenda);
            QuantidadeTotal = _itensVendas.Sum(x => x.Quantidade);
        }
    }
}
