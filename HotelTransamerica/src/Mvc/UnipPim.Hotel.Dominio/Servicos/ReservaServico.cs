using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class ReservaServico : ServicoBase, IReservaServico
    {
        private readonly IReservaRepositorio _reservaRepositorio;
        private readonly IAnuncioRepositorio _anuncioRepositorio;
        private readonly IQuartoRepositorio _quartoRepositorio;

        public ReservaServico(INotificacao notifier,
            IReservaRepositorio reservaRepositorio,
            IQuartoRepositorio quartoRepositorio, 
            IAnuncioRepositorio anuncioRepositorio) : base(notifier)
        {
            _reservaRepositorio = reservaRepositorio;
            _quartoRepositorio = quartoRepositorio;
            _anuncioRepositorio = anuncioRepositorio;
        }

        public async Task Insert(Reserva entity)
        {            
            var anuncio = await _anuncioRepositorio.Find(x => x.Id == entity.AnuncioId);
            var quarto = await _quartoRepositorio.Find(x => x.Id == anuncio.QuartoId);

            if (anuncio.Quantidade == 0)
            {
                Notificar("Anuncio não está mais valido.");
                return;
            }
            anuncio.SetQuantidade(anuncio.Quantidade - 1);
            if(anuncio.Quantidade == 0)
            {
                anuncio.DesativarAnuncio();
            }

            await _reservaRepositorio.Insert(entity);
            await _anuncioRepositorio.Update(anuncio);

            await _reservaRepositorio.SaveChanges();
            await _anuncioRepositorio.SaveChanges();
            await Task.CompletedTask;
        }

        public Task<Reserva> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Reserva entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}
