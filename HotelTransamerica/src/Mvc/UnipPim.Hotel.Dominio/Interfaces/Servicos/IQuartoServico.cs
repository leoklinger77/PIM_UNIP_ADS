using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface IQuartoServico : IServicoBase<Quarto>
    {
        Task<Paginacao<Quarto>> PaginacaoListaQuarto(int page, int size, string query);
    }
}
