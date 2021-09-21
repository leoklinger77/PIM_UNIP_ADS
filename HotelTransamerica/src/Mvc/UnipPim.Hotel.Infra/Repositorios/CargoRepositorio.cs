﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Infra.Data;
using X.PagedList;

namespace UnipPim.Hotel.Infra.Repositorios
{
    public class CargoRepositorio : ICargoRepositorio
    {
        private readonly HotelContext _context;

        public CargoRepositorio(HotelContext context)
        {
            _context = context;
        }

        public async Task<IPagedList<Cargo>> Paginacao(int page, int size, string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return await _context.Cargo.AsNoTracking().ToPagedListAsync(page, size);
            }

            return await _context.Cargo.AsNoTracking().Where(x => x.Nome.Contains(query)).ToPagedListAsync(page, size);
        }

        public async Task<Cargo> ObterPorId(Guid id)
        {
            return await _context.Cargo.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Cargo> Find(Expression<Func<Cargo, bool>> predicate)
        {
            return await _context.Cargo.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task Insert(Cargo entity)
        {
            await _context.Cargo.AddAsync(entity);
        }

        public async Task Update(Cargo entity)
        {
            _context.Cargo.Update(entity);
        }

        public async Task Delete(Cargo entity)
        {
            _context.Cargo.Remove(entity);
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
