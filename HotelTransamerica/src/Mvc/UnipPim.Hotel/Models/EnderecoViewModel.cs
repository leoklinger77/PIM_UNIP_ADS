using System;
using System.ComponentModel.DataAnnotations;

namespace UnipPim.Hotel.Models
{
    public class EnderecoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 2)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 2)]
        public string Complemento { get; set; }

        public string Referencia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 2)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(2, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 2)]
        public string Estado { get; set; }

        public Guid CidadeId { get; set; }

    }
}
