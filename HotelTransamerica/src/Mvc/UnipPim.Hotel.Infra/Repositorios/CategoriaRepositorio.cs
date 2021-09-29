using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;
using UnipPim.Hotel.Infra.Data;
using X.PagedList;

namespace UnipPim.Hotel.Infra.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly HotelContext _context;

        public CategoriaRepositorio(HotelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await _context.Categoria.AsNoTracking().ToListAsync();
        }

        public async Task<Paginacao<Categoria>> Paginacao(int page, int size, string query)
        {
            IPagedList<Categoria> list;
            if (string.IsNullOrEmpty(query))
            {
                list = await _context.Categoria.AsNoTracking().ToPagedListAsync(page, size);
            }
            else
            {
                list = await _context.Categoria.AsNoTracking()
                    .Where(x => x.Nome.Contains(query))
                    .ToPagedListAsync(page, size);
            }

            return new Paginacao<Categoria>()
            {
                List = list.ToList(),
                TotalResult = list.TotalItemCount,
                PageIndex = page,
                PageSize = page,
                Query = query
            };
        }

        public async Task<Categoria> ObterPorId(Guid id)
        {
            return await _context.Categoria.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Categoria> Find(Expression<Func<Categoria, bool>> predicate)
        {
            return await _context.Categoria.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task Insert(Categoria entity)
        {
            await _context.Categoria.AddAsync(entity);
        }

        public async Task Update(Categoria entity)
        {
            _context.Categoria.Update(entity);
        }

        public async Task Delete(Categoria entity)
        {
            _context.Categoria.Remove(entity);
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
