using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface ICargoRepositorio : IRepositorioBase<Cargo>
    {
        Task<Paginacao<Cargo>> Paginacao(int page, int size, string query);
        Task<IEnumerable<Cargo>> ObterTodos();
    }
}
