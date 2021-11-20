using System;
using System.ComponentModel.DataAnnotations;
using UnipPim.Hotel.Extensions.DataAnnotations;

namespace UnipPim.Hotel.Models
{
    public class FechamentoReservaViewModel
    {
        public AnuncioViewModel Anuncio { get; set; }
        public HospedeViewModel Hospede { get; set; }

        [Required(ErrorMessage = "Data de entrada é obrigatoria")]
        [DataEntradaAttribute]
        public DateTime Entrada { get; set; }

        [Required(ErrorMessage = "Data de saida é obrigatoria")]
        public DateTime Saida { get; set; }


        //Pagamento
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Número do Cartão")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "O Número do Cartão deve conter 16 digitos")]
        public string NumCartao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome escrito no Cartão")]
        public string NomeTitularCartao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Cpf do Titular do Cartão")]
        [CpfAttribute]
        public string CpfTitularCartao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "CVV")]
        public string Cvv { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Data de Vencimento")]
        public string DataExpiracao { get; set; }

    }
}
