using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface IGrupoFuncionarioServico : IServicoBase<GrupoFuncionario>
    {        
        Task<Paginacao<GrupoFuncionario>> PaginacaoGrupoFuncionario(int page, int size, string query);
    }
}
