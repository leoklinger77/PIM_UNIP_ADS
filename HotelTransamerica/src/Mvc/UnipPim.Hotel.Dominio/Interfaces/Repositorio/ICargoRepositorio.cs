using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using X.PagedList;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface ICargoRepositorio : IRepositorioBase<Cargo>
    {
        Task<IPagedList<Cargo>> Paginacao(int page, int size, string query);
    }
}
