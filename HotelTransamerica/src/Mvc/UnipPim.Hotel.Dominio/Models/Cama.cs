using System;
using UnipPim.Hotel.Dominio.Models.Enum;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Cama : Entity
    {
        public Guid QuaroId { get; private set; }
        public CamaTipo CamaTipo { get; private set; }
        public int Quantidade { get; private set; }
        public Quarto Quarto { get; private set; }

        protected Cama() { }

        public Cama(CamaTipo camaTipo, int quantidade)
        {
            CamaTipo = camaTipo;
            Quantidade = quantidade;
        }
    }
}
