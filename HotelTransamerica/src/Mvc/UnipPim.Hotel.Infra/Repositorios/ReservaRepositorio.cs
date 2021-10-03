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
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly HotelContext _context;

        public ReservaRepositorio(HotelContext context)
        {
            _context = context;
        }

        public async Task<Reserva> Find(Expression<Func<Reserva, bool>> predicate)
        {
            return await _context.Reserva.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<Reserva> ObterPorId(Guid id)
        {
            return await _context.Reserva.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(Reserva entity)
        {
            await _context.Reserva.AddAsync(entity);
        }

        public async Task Update(Reserva entity)
        {
            _context.Reserva.Update(entity);
        }

        public async Task Delete(Reserva entity)
        {
            _context.Reserva.Remove(entity);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
