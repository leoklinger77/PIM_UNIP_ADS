using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface IQuartoRepositorio : IRepositorioBase<Quarto>
    {
        Task<Paginacao<Quarto>> Paginacao(int page, int size, string query);

        Task AddCama(IEnumerable<Cama> cama);
        Task UpdateCama(Cama cama);
        Task DeleteCama(Cama cama);
        Task DeleteRangeCama(IEnumerable<Cama> cama);
    }
}
