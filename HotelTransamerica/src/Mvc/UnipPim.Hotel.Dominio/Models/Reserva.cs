using System;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Reserva : Entity, IAggregateRoot
    {
        public Guid AnuncioId { get; private set; }
        public Guid HospedeId { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public decimal CustoAdicional { get; private set; }
        public decimal ValorReserva { get; private set; }
        public Anuncio Anuncio { get; private set; }
        public Hospede Hospede { get; private set; }

        protected Reserva() { }

        public Reserva(Guid anuncioId, Guid hospedeId, DateTime checkIn, DateTime checkOut, decimal valorReserva)
        {
            AnuncioId = anuncioId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            ValorReserva = valorReserva;
            HospedeId = hospedeId;
        }
    }
}
