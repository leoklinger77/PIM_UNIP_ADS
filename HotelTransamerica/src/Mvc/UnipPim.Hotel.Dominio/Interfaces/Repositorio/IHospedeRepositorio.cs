using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface IHospedeRepositorio : IRepositorioBase<Hospede>
    {
        Task<Paginacao<Hospede>> Paginacao(int page, int size, string query);

        Task AddEmail(Email email);
        Task AddTelefone(Telefone telefone);
        Task AddEndereco(Endereco endereco);


        Task UpdateEmail(Email email);
        Task UpdateTelefone(Telefone telefone);
        Task UpdateEndereco(Endereco endereco);

        Task DeleteEmail(Email email);
        Task DeleteTelefone(Telefone telefone);
        Task DeleteEndereco(Endereco endereco);
    }
}
