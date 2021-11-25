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
    public class GrupoFuncionarioRepositorio : IGrupoFuncionarioRepositorio
    {
        private readonly HotelContext _context;

        public GrupoFuncionarioRepositorio(HotelContext context)
        {
            _context = context;
        }

        public async Task<Paginacao<GrupoFuncionario>> Paginacao(int page, int size, string query)
        {
            IPagedList<GrupoFuncionario> list;
            if (string.IsNullOrEmpty(query))
            {
                list = await _context.GrupoFuncionario.AsNoTracking().ToPagedListAsync(page, size);
            }
            else
            {
                list = await _context.GrupoFuncionario.AsNoTracking()
                    .Where(x => x.Nome.Contains(query))
                    .ToPagedListAsync(page, size);
            }

            return new Paginacao<GrupoFuncionario>()
            {
                List = list.ToList(),
                TotalResult = list.TotalItemCount,
                PageIndex = page,
                PageSize = size,
                Query = query
            };
        }

        public async Task<IEnumerable<GrupoFuncionario>> ObterTodos()
        {
            return await _context.GrupoFuncionario.AsNoTracking().ToListAsync();
        }

        public async Task<GrupoFuncionario> Find(Expression<Func<GrupoFuncionario, bool>> predicate)
        {
            return await _context.GrupoFuncionario.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<GrupoFuncionario> ObterPorId(Guid id)
        {
            return await _context.GrupoFuncionario.AsNoTracking().Include(x => x.Acesso).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(GrupoFuncionario entity)
        {
            await _context.GrupoFuncionario.AddAsync(entity);
        }

        public async Task AddAcessoLista(IEnumerable<Acesso> acesso)
        {
            await _context.Acesso.AddRangeAsync(acesso);
        }

        public async Task Update(GrupoFuncionario entity)
        {
            _context.GrupoFuncionario.Update(entity);
        }
        public async Task Delete(GrupoFuncionario entity)
        {
            _context.GrupoFuncionario.Remove(entity);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
