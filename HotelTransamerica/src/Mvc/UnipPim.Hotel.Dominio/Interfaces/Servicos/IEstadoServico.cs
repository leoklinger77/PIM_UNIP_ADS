using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface IEstadoServico
    {
        Task<Cidade> ObterCidadeComEstado(string cidade, string uf);
    }
}
