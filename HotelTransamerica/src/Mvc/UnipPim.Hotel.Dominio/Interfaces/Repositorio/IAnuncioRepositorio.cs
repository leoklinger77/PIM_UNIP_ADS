using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Repositorio
{
    public interface IAnuncioRepositorio : IRepositorioBase<Anuncio>
    {
        Task<Paginacao<Anuncio>> Paginacao(int page, int size, string query);

        Task AddFoto(Foto foto);
        Task UdateFoto(Foto foto);
        Task DeleteFoto(Foto foto);        
    }
}
