using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Quarto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public bool Televisor { get; private set; }
        public bool Hidromassagem { get; private set; }
        public string Descricao { get; private set; }
        public int NumeroQuarto { get; private set; }
        public bool Ocupado { get; private set; }

        private List<Anuncio> _anuncios = new List<Anuncio>();
        public IReadOnlyCollection<Anuncio> Anuncios => _anuncios;

        private List<Cama> _camas = new List<Cama>();
        public IReadOnlyCollection<Cama> Camas => _camas;

        protected Quarto() { }

        public Quarto(string nome, bool televisor, bool hidromassagem, string descricao, int numeroQuarto)
        {
            Nome = nome;
            Televisor = televisor;
            Hidromassagem = hidromassagem;
            Descricao = descricao;
            NumeroQuarto = numeroQuarto;
            QuartoDisponivel();
        }
        public void QuartoOcupado()
        {
            Ocupado = true;
        }
        public void QuartoDisponivel()
        {
            Ocupado = false;
        }

        public void AddCama(Cama cama)
        {
            _camas.Add(cama);
        }
    }
}
