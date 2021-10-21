using System;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Foto : Entity
    {
        public Guid AnuncioId { get; private set; }
        public string Caminho { get; private set; }
        public Anuncio Anuncio { get; private set; }
        
        public Foto() { }

        public Foto(string caminho)
        {
            Caminho = caminho;
        }

        internal void SetCaminho(string camiho)
        {
            Caminho = camiho;
        }

        internal void SetAnuncio(Guid anuncioId)
        {
            AnuncioId = anuncioId;
        }
    }
}
