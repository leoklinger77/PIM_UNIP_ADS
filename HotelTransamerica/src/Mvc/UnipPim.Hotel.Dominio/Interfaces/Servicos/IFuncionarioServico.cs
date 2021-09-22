using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using X.PagedList;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface IFuncionarioServico
    {
        Task<Funcionario> ObterPorId(Guid id);
        Task<IPagedList<Funcionario>> PaginacaoListaFuncionario(int page, int size, string query);

        Task Insert(Funcionario funcionario);
        Task Update(Funcionario funcionario);
        Task DeletarFuncionario(Funcionario funcionario);
    }
}
