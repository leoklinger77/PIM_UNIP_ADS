using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using X.PagedList;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface IFuncionarioRepositorio : IRepositorioBase<Funcionario>
    {
        Task<Email> ObterEmailPorId(Guid funcionarioId, Guid id);
        Task<Telefone> ObterTelefonePorId(Guid funcionarioId, Guid id);

        Task AddEmail(Email email);
        Task AddTelefone(Telefone telefone);
        Task AddEndereco(Endereco endereco);


        Task UpdateEmail(Email email);
        Task UpdateTelefone(Telefone telefone);
        Task UpdateEndereco(Endereco endereco);

        Task DeleteEmail(Email email);
        Task DeleteTelefone(Telefone telefone);
        Task DeleteEndereco(Endereco endereco);
        Task<IPagedList<Funcionario>> Paginacao(int page, int size, string query);
    }
}
