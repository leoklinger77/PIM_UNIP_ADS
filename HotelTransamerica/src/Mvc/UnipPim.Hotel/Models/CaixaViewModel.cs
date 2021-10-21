using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class CaixaViewModel
    {
        public Guid FuncionarioId { get; set; }
        public decimal ValorInicial { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime Fechamento { get; set; }

        public IEnumerable<OrderVendaViewModel> OrderVendas { get; set; } = new List<OrderVendaViewModel>();        
    }

    public class OrderVendaViewModel
    {

    }

}
