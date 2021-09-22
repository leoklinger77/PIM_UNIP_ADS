using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface IHospedeServico
    {
        Task<Hospede> ObterPorId(Guid id);
        Task<Paginacao<Hospede>> PaginacaoListaFuncionario(int page, int size, string query);

        Task Insert(Hospede hospede);
        Task Update(Hospede hospede);
        Task Deletar(Hospede hospede);
    }
}
