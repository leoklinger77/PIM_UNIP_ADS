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
    public class QuartoRepositorio : IQuartoRepositorio
    {
        private readonly HotelContext _hotelContext;

        public QuartoRepositorio(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<Paginacao<Quarto>> Paginacao(int page, int size, string query)
        {
            IPagedList<Quarto> list;
            if (string.IsNullOrEmpty(query))
            {
                list = await _hotelContext.Quarto.AsNoTracking().ToPagedListAsync(page, size);
            }
            else
            {
                list = await _hotelContext.Quarto.AsNoTracking()
                    .Where(x => x.NumeroQuarto.ToString().Contains(query))
                    .ToPagedListAsync(page, size);
            }

            return new Paginacao<Quarto>()
            {
                List = list.ToList(),
                TotalResult = list.TotalItemCount,
                PageIndex = page,
                PageSize = page,
                Query = query
            };
        }

        public async Task<Quarto> Find(Expression<Func<Quarto, bool>> predicate)
        {
            return await _hotelContext.Quarto.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<Frigobar> ObterFrigobar(Guid id)
        {
            var frigobar =  await _hotelContext
               .Frigobar
               .Include(x => x.ProdutosConsumido)
               .Include(x => x.ProdutosFrigobar)
               .AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
                        
            foreach (var item in frigobar.ProdutosFrigobar)            
                item.Produto = await _hotelContext.Produto.AsNoTracking().Where(x => x.Id == item.ProdutoId).FirstAsync();

            foreach (var item in frigobar.ProdutosConsumido)
                item.Produto = await _hotelContext.Produto.AsNoTracking().Where(x => x.Id == item.ProdutoId).FirstAsync();

            return frigobar;
        }

        public async Task<Quarto> ObterPorId(Guid id)
        {
            return await _hotelContext
                .Quarto
                .Include(x => x.Camas)
                .Include(x => x.Frigobar)
                .Include(x => x.Frigobar.ProdutosConsumido)
                .Include(x => x.Frigobar.ProdutosFrigobar)
                .AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(Quarto entity)
        {
            await _hotelContext.Quarto.AddAsync(entity);
        }
        public async Task AddCama(IEnumerable<Cama> cama)
        {
            await _hotelContext.Cama.AddRangeAsync(cama);
        }

        public async Task Update(Quarto entity)
        {
            _hotelContext.Quarto.Update(entity);
        }

        public async Task UpdateCama(Cama cama)
        {
            _hotelContext.Cama.Update(cama);
        }

        public async Task Delete(Quarto entity)
        {
            _hotelContext.Quarto.Remove(entity);
        }

        public async Task DeleteCama(Cama cama)
        {
            _hotelContext.Cama.Remove(cama);
        }
        public async Task DeleteRangeCama(IEnumerable<Cama> cama)
        {
            _hotelContext.Cama.RemoveRange(cama);
        }

        public async Task<int> SaveChanges()
        {
            return await _hotelContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _hotelContext?.DisposeAsync();
        }

        public async Task AddFrigobar(Frigobar frigobar)
        {
            await _hotelContext.Frigobar.AddAsync(frigobar);
        }

        public async Task AddProdutoFrigobar(ProdutosFrigobar produtoFrigobar)
        {
            await _hotelContext.ProdutosFrigobar.AddAsync(produtoFrigobar);
        }


    }
}
