using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Quarto : Entity, IAggregateRoot
    {
        public bool Televisor { get; private set; }
        public bool Hidromassagem { get; private set; }
        public string Descricao { get; private set; }

        private List<Anuncio> _anuncios = new List<Anuncio>();
        public IReadOnlyCollection<Anuncio> Anuncios => _anuncios;

        private List<Cama> _camas = new List<Cama>();
        public IReadOnlyCollection<Cama> Camas => _camas;

        public Quarto() { }

        public Quarto(bool televisor, bool hidromassagem, string descricao)
        {
            Televisor = televisor;
            Hidromassagem = hidromassagem;
            Descricao = descricao;
        }
    }
}
