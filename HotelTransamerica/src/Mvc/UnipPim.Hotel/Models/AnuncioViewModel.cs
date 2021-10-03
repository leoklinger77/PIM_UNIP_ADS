using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnipPim.Hotel.Models
{
    public class AnuncioViewModel
    {
        public Guid Id { get; set; }
        public Guid FuncionarioId { get;  set; }
        public Guid QuartoId { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo {0} deve conter {2} a {1} caracteres.", MinimumLength = 5)]
        [Display(Name = "Nome do anuncio")]
        public string Nome { get;  set; }
        public bool Ativo { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Quantidade em Estoque")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser maior que 0.")]
        public int Quantidade { get;  set; }

        [Display(Name = "Valor do anuncio")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo {0} deve ser maior que R$0,00.")]
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
