using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class OrderVendaViewModel
    {
        public Guid Id { get; set; }
        public Guid CaixaId { get; set; }
        public DateTime Instante { get; set; }
        public string Cpf { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public int QuantidadeTotal { get; set; }

        public ICollection<ItensVendaViewModel> ItensVenda { get; set; }
    }

    public class ItensVendaViewModel
    {
        public Guid OrderVendaId { get; set; }
        public Guid ProdutoId { get; set; }

        public decimal PrecoVenda { get; set; }
        public int Quantidade { get; set; }
    }
}
