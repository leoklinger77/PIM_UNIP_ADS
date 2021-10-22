using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Infra.Data;

namespace UnipPim.Hotel.Infra.Repositorios
{
    public class CaixaRepositorio : ICaixaRepositorio
    {
        private readonly HotelContext _hotelContext;

        public CaixaRepositorio(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        public async Task<Caixa> ObterCaixaPorFuncionario(Guid id)
        {
            return await _hotelContext.Caixa.AsNoTracking().Where(x => x.FuncionarioId == id && x.CaixaTipo == CaixaTipo.Aberto).FirstOrDefaultAsync();
        }
        public async Task<Caixa> Find(Expression<Func<Caixa, bool>> predicate)
        {
            return await _hotelContext.Caixa.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }
        public async Task<Caixa> ObterPorId(Guid id)
        {
            return await _hotelContext.Caixa.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(Caixa entity)
        {
            await _hotelContext.Caixa.AddAsync(entity);
        }

        public async Task Update(Caixa entity)
        {
            _hotelContext.Caixa.Update(entity);
        }
        public async Task Delete(Caixa entity)
        {
            _hotelContext.Caixa.Remove(entity);
        }
        public async Task<int> SaveChanges()
        {
            return await _hotelContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _hotelContext?.DisposeAsync();
        }
        
        public async Task<OrderVenda> ObterOrderRascunho(Guid funcId)
        {
            return await _hotelContext.OrderVenda.AsNoTracking().Where(x => x.Caixa.FuncionarioId == funcId && x.Tipo == OrderTipo.Rascunho).FirstOrDefaultAsync();
        }

        public async Task Insert(OrderVenda order)
        {
            await _hotelContext.OrderVenda.AddAsync(order);
        }

        public async Task Update(OrderVenda order)
        {
            _hotelContext.OrderVenda.Update(order);
        }

        public async Task Update(IEnumerable<ItensVenda> itensVendas)
        {
            _hotelContext.ItensVenda.UpdateRange(itensVendas);
        }
    }
}
