using System;
using System.Collections.Generic;
using System.Linq;
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Models
{
    public class OrderVenda : Entity
    {
        public Guid CaixaId { get; private set; }
        public DateTime Instante { get; private set; }
        public string Cpf { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public int QuantidadeTotal { get; private set; }
        public OrderTipo Tipo { get; private set; }

        private List<ItensVenda> _itensVendas = new List<ItensVenda>();
        public IReadOnlyCollection<ItensVenda> ItensVendas => _itensVendas;
        public Caixa Caixa { get; private set; }

        protected OrderVenda() { }
        public OrderVenda(Guid caixaId, string cpf = null)
        {
            CaixaId = caixaId;
            Cpf = cpf;

            Instante = DateTime.Now;
            Tipo = OrderTipo.Rascunho;            
        }

        public void AddItem(ItensVenda itensVenda)
        {
            var item = _itensVendas.Where(x => x.ProdutoId == itensVenda.ProdutoId).FirstOrDefault();
            if (item != null)
            {
                if (item.PrecoVenda != itensVenda.PrecoVenda)
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

            Calcula();
        }

        public void UpdateItem(ItensVenda itensVenda)
        {
            var item = _itensVendas.Where(x => x.ProdutoId == itensVenda.ProdutoId).FirstOrDefault();
            if (item == null)
            {
                throw new DomainException("Produto não encontrado");
            }
            _itensVendas.Remove(item);
            _itensVendas.Add(itensVenda);

            Calcula();
        }

        private void Calcula()
        {
            ValorTotal = _itensVendas.Sum(x => x.PrecoVenda * x.Quantidade);
            QuantidadeTotal = _itensVendas.Sum(x => x.Quantidade);
        }
    }
}
