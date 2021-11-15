using System;
using System.Collections.Generic;
using System.Text;
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

        public ReservaServico(INotificacao notifier, IReservaRepositorio reservaRepositorio) : base(notifier)
        {
            _reservaRepositorio = reservaRepositorio;
        }

        public async Task Insert(Reserva entity)
        {
            await _reservaRepositorio.Insert(entity);

            await _reservaRepositorio.SaveChanges();

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
