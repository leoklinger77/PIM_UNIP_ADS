using System;
using UnipPim.Hotel.Dominio.Models.Enum;

namespace UnipPim.Hotel.Models
{
    public class CamaViewModel
    {
        public Guid QuaroId { get; set; }
        public CamaTipo CamaTipo { get; set; }
        public int Quantidade { get; set; }
        public QuartoViewModel Quarto { get; set; }
    }
}
