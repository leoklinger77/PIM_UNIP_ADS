using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface ICaixaRepositorio : IRepositorioBase<Caixa>
    {
        Task<Caixa> ObterCaixaPorFuncionario(Guid id);
        Task<OrderVenda> ObterOrderRascunho(Guid funcId);

        Task Insert(OrderVenda order);
        Task Insert(ItensVenda item);
        Task Update(OrderVenda order);
        Task Update(IEnumerable<ItensVenda> itensVendas);
        Task RemoverItemVenda(ItensVenda itemVenda);
    }
}
