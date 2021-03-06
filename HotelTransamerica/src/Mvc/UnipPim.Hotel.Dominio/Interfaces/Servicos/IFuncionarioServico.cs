using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface IFuncionarioServico
    {
        Task<List<Funcionario>> ObterTodos();
        Task<Funcionario> ObterPorId(Guid id);
        Task<Paginacao<Funcionario>> PaginacaoListaFuncionario(int page, int size, string query);

        Task Insert(Funcionario funcionario);
        Task Update(Funcionario funcionario);
        Task DeletarFuncionario(Guid id);
    }
}
