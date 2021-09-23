using System.Threading.Tasks;
using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface IGrupoFuncionarioRepositorio : IRepositorioBase<GrupoFuncionario>
    {
        Task<Paginacao<GrupoFuncionario>> Paginacao(int page, int size, string query);
        Task<IEnumerable<GrupoFuncionario>> ObterTodos();


        Task AddAcessoLista(IEnumerable<Acesso> acesso);
    }
}
