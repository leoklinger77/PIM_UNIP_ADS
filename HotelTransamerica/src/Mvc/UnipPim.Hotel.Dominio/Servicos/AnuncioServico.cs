using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class AnuncioServico : ServicoBase, IAnuncioServico
    {
        private readonly IAnuncioRepositorio _anuncioRepositorio;

        public AnuncioServico(INotificacao notificacao, 
                                IAnuncioRepositorio anuncioRepositorio) 
                                : base(notificacao)
        {
            _anuncioRepositorio = anuncioRepositorio;
        }
        public async Task<Paginacao<Anuncio>> PaginacaoListaAnuncio(int page, int size, string query) 
            => await _anuncioRepositorio.Paginacao(page, size, query);

        public async Task<Anuncio> ObterPorId(Guid id)
        {
            var result = await _anuncioRepositorio.ObterPorId(id);
            if(result == null)
            {
                Notificar("Anuncio não encontrado.");
            }
            return result;
        }
        public async Task Insert(Anuncio entity)
        {
            throw new NotImplementedException();
        }
        public async Task Update(Anuncio entity)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _anuncioRepositorio.Dispose();
        }
    }
}
