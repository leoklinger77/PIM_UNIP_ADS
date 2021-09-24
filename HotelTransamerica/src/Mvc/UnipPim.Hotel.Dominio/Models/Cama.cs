using System;
using UnipPim.Hotel.Dominio.Models.Enum;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Cama : Entity
    {
        public Guid QuaroId { get; private set; }
        public CamaTipo CamaTipo { get; private set; }                
        public Quarto Quarto { get; private set; }

        public Cama() { }

        public Cama(CamaTipo camaTipo)
        {
            CamaTipo = camaTipo;
        }
    }
}
