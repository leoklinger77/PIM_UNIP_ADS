using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface IEstadoRepositorio : IRepositorioBase<Estado>
    {
        Task<Cidade> ObterCidadeComEstado(string cidade, string uf);
    }
}
