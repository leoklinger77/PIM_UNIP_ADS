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
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly HotelContext _context;

        public ProdutoRepositorio(HotelContext context)
        {
            _context = context;
        }

        public async Task<Paginacao<Produto>> Paginacao(int page, int size, string query)
        {
            IPagedList<Produto> list;
            if (string.IsNullOrEmpty(query))
            {
                list = await _context.Produto.Include(x => x.Categoria).AsNoTracking().ToPagedListAsync(page, size);
            }
            else
            {
                list = await _context.Produto.Include(x => x.Categoria).AsNoTracking()
                    .Where(x => x.Nome.Contains(query))
                    .ToPagedListAsync(page, size);
            }

            return new Paginacao<Produto>()
            {
                List = list.ToList(),
                TotalResult = list.TotalItemCount,
                PageIndex = page,
                PageSize = page,
                Query = query
            };
        }

        public async Task<IEnumerable<Produto>> ProdutosDisponiveis()
        {
            return await _context.Produto.AsNoTracking().Where(x => x.QuantidadeEstoque > 0).ToListAsync();
        }
        public async Task<Produto> Find(Expression<Func<Produto, bool>> predicate)
        {
            return await _context.Produto.Include(x => x.Categoria).AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produto
                            .Include(x => x.Categoria)
                            .AsNoTracking()
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task Insert(Produto entity)
        {
            await _context.Produto.AddAsync(entity);
        }

        public async Task Update(Produto entity)
        {
            _context.Produto.Update(entity);
        }

        public async Task Delete(Produto entity)
        {
            _context.Produto.Remove(entity);
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
