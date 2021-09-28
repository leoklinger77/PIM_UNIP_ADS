using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class AnuncioViewModel
    {
        public Guid Id { get; set; }
        public Guid FuncionarioId { get;  set; }
        public Guid QuartoId { get;  set; }
        public string Nome { get;  set; }
        public bool Ativo { get;  set; }
        public int Quantidade { get;  set; }
        public decimal Custo { get;  set; }

        public FuncionarioViewModel Funcionario { get;  set; }
        public QuartoViewModel Quarto { get;  set; }
        public IEnumerable<FotoViewModel> Fotos { get; set; } = new List<FotoViewModel>();
        public IEnumerable<QuartoViewModel> ListaQuarto { get; set; } = new List<QuartoViewModel>();
    }

    public class FotoViewModel
    {
        public Guid Id { get; set; }
        public Guid AnuncioId { get; set; }
        public IFormFile Foto { get; set; }
        public string Caminho { get; set; }

        public AnuncioViewModel Anuncio { get; set; }
    }
}
