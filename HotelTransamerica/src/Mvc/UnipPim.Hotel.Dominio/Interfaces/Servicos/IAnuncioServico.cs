using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Interfaces.Servicos
{
    public interface IAnuncioServico : IServicoBase<Anuncio>
    {
        Task<Paginacao<Anuncio>> PaginacaoListaAnuncio(int page, int size, string query);
        Task<IEnumerable<Quarto>> ListarQuartosDisponiveis();
        Task<IEnumerable<Anuncio>> TresAnunciosAleatorios();
    }
}
