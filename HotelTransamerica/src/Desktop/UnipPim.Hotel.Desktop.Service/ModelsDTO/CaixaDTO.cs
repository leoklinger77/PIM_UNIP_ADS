using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Desktop.Service.ModelsDTO
{
    public class CaixaDTO
    {
        public Guid FuncionarioId { get; set; }
        public decimal ValorInicial { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime? Fechamento { get; set; }
        public IEnumerable<OrderVendaDTO> OrderVendas { get; set; } = new List<OrderVendaDTO>();
    }

    public class OrderVendaDTO
    {

    }
}
