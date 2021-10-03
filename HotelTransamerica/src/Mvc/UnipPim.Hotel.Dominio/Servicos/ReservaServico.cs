using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class ReservaServico : IReservaServico
    {
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Insert(Reserva entity)
        {
            throw new NotImplementedException();
        }

        public Task<Reserva> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Reserva entity)
        {
            throw new NotImplementedException();
        }
    }
}
