using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface IProdutoServico : IServicoBase<Produto>
    {
        Task<Paginacao<Produto>> PaginacaoListaProduto(int page, int size, string query);
        Task<IEnumerable<Categoria>> ListaCategoria();
        Task<IEnumerable<Produto>> ProdutosDisponiveis();
    }
}
