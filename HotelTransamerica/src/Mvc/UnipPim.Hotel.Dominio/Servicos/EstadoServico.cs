using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class EstadoServico : ServicoBase, IEstadoServico
    {
        private readonly IEstadoRepositorio _estadoRepositorio;

        public EstadoServico(INotificacao notifier, IEstadoRepositorio estadoRepositorio) : base(notifier)
        {
            _estadoRepositorio = estadoRepositorio;
        }


        public async Task<Cidade> ObterCidadeComEstado(string cidade, string uf)
        {
            return await _estadoRepositorio.ObterCidadeComEstado(cidade, uf);
        }
    }
}
