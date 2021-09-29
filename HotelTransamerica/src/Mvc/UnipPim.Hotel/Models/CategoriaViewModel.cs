using System;
using System.ComponentModel.DataAnnotations;

namespace UnipPim.Hotel.Models
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }
    }
}
