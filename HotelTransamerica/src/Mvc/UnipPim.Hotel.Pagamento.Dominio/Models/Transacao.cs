using System;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Pagamento.Dominio.Models
{
    public class Transacao : Entity
    {
        public Guid PedidoId { get; set; }
        public Guid PagamentoId { get; set; }
        public decimal Total { get; set; }
        public StatusTransacao StatusTransacao { get; set; }
        
        public Pagamento Pagamento { get; set; }
    }

    public enum StatusTransacao
    {
        Pago = 1,
        Recusado = 2
    }
}
