using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface ICaixaRepositorio : IRepositorioBase<Caixa>
    {
        Task<Caixa> ObterCaixaPorFuncionario(Guid id);
    }
}
