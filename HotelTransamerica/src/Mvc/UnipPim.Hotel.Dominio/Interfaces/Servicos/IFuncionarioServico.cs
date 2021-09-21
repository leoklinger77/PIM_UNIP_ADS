using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface IFuncionarioServico
    {
        Task<bool> Insert(Funcionario funcionario);
    }
}
