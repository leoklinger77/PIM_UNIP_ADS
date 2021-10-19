using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface ICargoServico
    {
        Task<Paginacao<Cargo>> PaginacaoListaCargo(int page, int size, string query);
        Task<IEnumerable<Cargo>> ObterTodos();

        Task Insert(Cargo cargo);
        Task Update(Cargo cargo);

        Task<Cargo> ObterPorId(Guid id);
        Task DeletarCargo(Guid id);
    }
}
