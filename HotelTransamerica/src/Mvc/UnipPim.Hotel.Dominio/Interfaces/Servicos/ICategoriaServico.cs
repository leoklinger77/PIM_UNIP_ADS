using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface ICategoriaServico : IServicoBase<Categoria>
    {
        Task<Paginacao<Categoria>> PaginacaoListaCategoria(int page, int size, string query);
    }
}
