using System;
using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Models.Enum;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Caixa : Entity, IAggregateRoot
    {
        public Guid FuncionarioId { get; private set; }
        public decimal ValorInicial { get; private set; }
        public DateTime Abertura { get; private set; }
        public DateTime? Fechamento { get; private set; }
        public CaixaTipo CaixaTipo { get; private set; }

        private List<OrderVenda> _orderVendas = new List<OrderVenda>();
        public IReadOnlyCollection<OrderVenda> OrderVendas => _orderVendas;
        public Funcionario Funcionario { get; private set; }

        protected Caixa() { }

        public Caixa(decimal valorInicial, Guid funcionarioId)
        {
            ValorInicial = valorInicial;
            FuncionarioId = funcionarioId;
            Abertura = DateTime.Now;
            CaixaTipo = CaixaTipo.Aberto;
        }

        public void FecharCaixa()
        {
            Fechamento = DateTime.Now;
            CaixaTipo = CaixaTipo.Fechado;
        }
    }
}
