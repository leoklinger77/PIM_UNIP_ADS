using System;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Models
{
    public class ItensVenda
    {
        public Guid OrderVendaId { get; private set; }
        public Guid ProdutoId { get; private set; }

        public decimal PrecoVenda { get; private set; }
        public int Quantidade { get; private set; }

        public OrderVenda OrderVenda { get; private set; }
        public Produto Produto { get; private set; }

        public ItensVenda(Guid orderVendaId, Guid produtoId, decimal precoVenda, int quantidade)
        {
            OrderVendaId = orderVendaId;
            ProdutoId = produtoId;
            PrecoVenda = precoVenda;
            Quantidade = quantidade;
        }

        internal void AddQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }
        internal void RemoveQuantidade(int quantidade)
        {
            if (Quantidade - quantidade < 0)
            {
                Quantidade = 0;
            }
            else
            {
                Quantidade -= quantidade;
            }
        }

        internal void SetPreco(decimal value)
        {
            if (value <= 0) throw new DomainException("O valor não pode ser 0.");

            PrecoVenda = value;
        }
    }
}
