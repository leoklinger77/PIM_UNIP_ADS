using System;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Pagamento.Dominio.Models
{
    public class Pagamento : Entity, IAggregateRoot
    {
        public Guid PedidoId { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }

        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

        // EF. Rel.
        public Transacao Transacao { get; set; }
    }
}
