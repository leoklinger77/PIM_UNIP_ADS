using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface IFrigobarRepositorio : IRepositorioBase<Frigobar>
    {
        Task<Paginacao<ProdutosFrigobar>> PaginacaoProdutos(int page, int size, string query);
        Task InserirProduto(IEnumerable<ProdutosFrigobar> produtos);
        Task RemoverProduto(ProdutosFrigobar produtos);


        Task<Paginacao<ProdutosConsumidos>> PaginacaoProdutosConsumidos(int page, int size, string query);
        Task InserirProdutoConsumido(IEnumerable<ProdutosConsumidos> produtos);
        Task RemoverProdutoConsumido(ProdutosConsumidos produtos);
    }
}
