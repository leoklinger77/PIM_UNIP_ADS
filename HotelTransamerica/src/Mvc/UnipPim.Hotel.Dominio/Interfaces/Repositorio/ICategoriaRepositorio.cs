using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface ICategoriaRepositorio : IRepositorioBase<Categoria>
    {
        Task<Paginacao<Categoria>> Paginacao(int page, int size, string query);
        Task<IEnumerable<Categoria>> ObterTodos();
    }
}
