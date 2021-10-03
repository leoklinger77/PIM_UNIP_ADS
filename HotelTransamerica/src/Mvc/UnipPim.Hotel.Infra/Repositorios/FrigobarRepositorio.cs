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
    public class FrigobarRepositorio : IFrigobarRepositorio
    {
        private readonly HotelContext _context;

        public FrigobarRepositorio(HotelContext context)
        {
            _context = context;
        }

        public async Task<Paginacao<ProdutosFrigobar>> PaginacaoProdutos(int page, int size, string query)
        {
            IPagedList<ProdutosFrigobar> list;
            if (string.IsNullOrEmpty(query))
            {
                list = await _context.ProdutosFrigobar.AsNoTracking().ToPagedListAsync(page, size);
            }
            else
            {
                list = await _context.ProdutosFrigobar.AsNoTracking()
                    .Where(x => x.Produto.Nome.Contains(query))
                    .ToPagedListAsync(page, size);
            }

            return new Paginacao<ProdutosFrigobar>()
            {
                List = list.ToList(),
                TotalResult = list.TotalItemCount,
                PageIndex = page,
                PageSize = page,
                Query = query
            };
        }

        public async Task<Paginacao<ProdutosConsumidos>> PaginacaoProdutosConsumidos(int page, int size, string query)
        {
            IPagedList<ProdutosConsumidos> list;
            if (string.IsNullOrEmpty(query))
            {
                list = await _context.ProdutosConsumidos.AsNoTracking().ToPagedListAsync(page, size);
            }
            else
            {
                list = await _context.ProdutosConsumidos.AsNoTracking()
                    .Where(x => x.Produto.Nome.Contains(query))
                    .ToPagedListAsync(page, size);
            }

            return new Paginacao<ProdutosConsumidos>()
            {
                List = list.ToList(),
                TotalResult = list.TotalItemCount,
                PageIndex = page,
                PageSize = page,
                Query = query
            };
        }

        public async Task<Frigobar> ObterPorId(Guid id)
        {
            return await _context.Frigobar
               .Include(x => x.ProdutosConsumido)
               .Include(x => x.ProdutosFrigobar)
               .AsNoTracking()
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();
        }

        public async Task<Frigobar> Find(Expression<Func<Frigobar, bool>> predicate)
        {
            return await _context.Frigobar
                .Include(x => x.ProdutosConsumido)
                .Include(x => x.ProdutosFrigobar)
                .AsNoTracking()
                .Where(predicate)
                .FirstOrDefaultAsync();
        }

        public async Task Insert(Frigobar entity)
        {
            await _context.Frigobar.AddAsync(entity);
        }

        public async Task InserirProduto(IEnumerable<ProdutosFrigobar> produtos)
        {
            await _context.ProdutosFrigobar.AddRangeAsync(produtos);
        }

        public async Task InserirProdutoConsumido(IEnumerable<ProdutosConsumidos> produtos)
        {
            await _context.ProdutosConsumidos.AddRangeAsync(produtos);
        }

        public async Task Update(Frigobar entity)
        {
            _context.Frigobar.Update(entity);
        }

        public async Task Delete(Frigobar entity)
        {
            _context.Frigobar.Remove(entity);
        }

        public async Task RemoverProduto(ProdutosFrigobar produto)
        {
            _context.ProdutosFrigobar.Remove(produto);
        }

        public async Task RemoverProdutoConsumido(ProdutosConsumidos produto)
        {
            _context.ProdutosConsumidos.Remove(produto);
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
