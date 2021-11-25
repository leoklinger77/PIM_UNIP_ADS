using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface IFuncionarioRepositorio : IRepositorioBase<Funcionario>
    {
        Task<Email> ObterEmailPorId(Guid funcionarioId, Guid id);
        Task<Telefone> ObterTelefonePorId(Guid funcionarioId, Guid id);

        Task AddEmail(IEnumerable<Email> email);
        Task AddTelefone(IEnumerable<Telefone> telefone);
        Task AddEndereco(IEnumerable<Endereco> endereco);


        Task UpdateEmail(IEnumerable<Email> email);
        Task UpdateTelefone(IEnumerable<Telefone> telefone);
        Task UpdateEndereco(IEnumerable<Endereco> endereco);

        Task DeleteEmail(Email email);
        Task DeleteTelefone(Telefone telefone);
        Task DeleteEndereco(Endereco endereco);

        Task DeleteEmail(IEnumerable<Email> email);
        Task DeleteTelefone(IEnumerable<Telefone> telefone);
        Task DeleteEndereco(IEnumerable<Endereco> endereco);
        Task<Paginacao<Funcionario>> Paginacao(int page, int size, string query);
        Task<List<Funcionario>> ObterTodos();
    }
}
