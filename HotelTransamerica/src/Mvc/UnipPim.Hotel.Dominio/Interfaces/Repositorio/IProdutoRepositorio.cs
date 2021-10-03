using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        Task<Paginacao<Produto>> Paginacao(int page, int size, string query);
        Task<IEnumerable<Produto>> ProdutosDisponiveis();
    }
}
