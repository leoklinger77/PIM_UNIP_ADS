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
    public class AnuncioRepositorio : IAnuncioRepositorio
    {
        private readonly HotelContext _hotelContext;

        public AnuncioRepositorio(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<Paginacao<Anuncio>> Paginacao(int page, int size, string query)
        {
            IPagedList<Anuncio> list;
            if (string.IsNullOrEmpty(query))
            {
                list = await _hotelContext.Anuncio.AsNoTracking().ToPagedListAsync(page, size);
            }
            else
            {
                list = await _hotelContext.Anuncio.AsNoTracking()
                    .Where(x => x.Nome.Contains(query))
                    .ToPagedListAsync(page, size);
            }

            return new Paginacao<Anuncio>()
            {
                List = list.ToList(),
                TotalResult = list.TotalItemCount,
                PageIndex = page,
                PageSize = page,
                Query = query
            };
        }
        public async Task<IEnumerable<Anuncio>> TresAnunciosAleatorios()
        {
            return await _hotelContext.Anuncio.Include(x => x.Fotos).Include(x => x.Quarto).OrderBy(x => Guid.NewGuid()).Take(3).ToListAsync();
        }

        public async Task<IEnumerable<Quarto>> ObterQuartosDisponiveis()
        {
            return await _hotelContext.Quarto.AsNoTracking().Where(x => x.Ocupado == false).ToListAsync();
        }

        public async Task<Anuncio> Find(Expression<Func<Anuncio, bool>> predicate)
        {
            return await _hotelContext.Anuncio.FirstOrDefaultAsync();
        }

        public async Task<Anuncio> ObterPorId(Guid id)
        {
            return await _hotelContext.Anuncio.Include(x => x.Fotos).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(Anuncio entity)
        {
            await _hotelContext.Anuncio.AddAsync(entity);
        }

        public async Task AddFoto(Foto foto)
        {
            await _hotelContext.Foto.AddAsync(foto);
        }

        public async Task UdateFoto(Foto foto)
        {
            _hotelContext.Foto.Update(foto);
        }

        public async Task Update(Anuncio entity)
        {
            _hotelContext.Anuncio.Update(entity);
        }

        public async Task Delete(Anuncio entity)
        {
            _hotelContext.Anuncio.Remove(entity);
        }

        public async Task DeleteFoto(Foto foto)
        {
            _hotelContext.Foto.Remove(foto);
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
