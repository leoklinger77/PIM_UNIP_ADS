using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UnipPim.Hotel.Models
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Categoria")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo {0} deve conter {2} a {1} caracteres.", MinimumLength = 13)]
        [Display(Name = "Código de barras")]
        public string CodigoBarras { get;  set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Quantidade em Estoque")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser maior que 0.")]
        public int QuantidadeEstoque { get;  set; }

        [Display(Name = "Quantidade Vendida")]
        public int QuantidadeVendida { get; set; }

        [Display(Name = "Valor de venda")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.01,double.MaxValue, ErrorMessage ="O campo {0} deve ser maior que R$0,00.")]
        public decimal Valor { get;  set; }
        public CategoriaViewModel Categoria { get;  set; }

        [JsonIgnore]
        public IEnumerable<CategoriaViewModel> ListaCategoria { get; set; } = new List<CategoriaViewModel>();
    }
}
