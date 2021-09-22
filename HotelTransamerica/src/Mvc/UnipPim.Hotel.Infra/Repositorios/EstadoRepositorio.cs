using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Infra.Data;

namespace UnipPim.Hotel.Infra.Repositorios
{
    public class EstadoRepositorio : IEstadoRepositorio
    {
        private readonly HotelContext _hotelContext;

        public EstadoRepositorio(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }


        public async Task<Estado> Find(Expression<Func<Estado, bool>> predicate)
        {
            return await _hotelContext.Estado.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<Cidade> ObterCidadeComEstado(string cidade, string uf)
        {
            return await _hotelContext.Cidade.AsNoTracking().Where(x => x.Nome == cidade && x.Estado.Uf == uf).FirstOrDefaultAsync();
        }

        public async Task<Estado> ObterPorId(Guid id)
        {
            return await _hotelContext.Estado.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(Estado entity)
        {
            await _hotelContext.Estado.AddAsync(entity);
        }

        public async Task Update(Estado entity)
        {
            _hotelContext.Estado.Update(entity);
        }

        public async Task Delete(Estado entity)
        {
            _hotelContext.Estado.Remove(entity);
        }

        public async Task<int> SaveChanges()
        {
            return await _hotelContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _hotelContext?.DisposeAsync();
        }
    }
}
