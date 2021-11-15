using System;

namespace UnipPim.Hotel.Models
{
    public class FechamentoReservaViewModel
    {
        public AnuncioViewModel Anuncio { get; set; }
        public HospedeViewModel Hospede { get; set; }       

        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }       


        //Pagamento
        public string NumCartao { get; set; }
        public string NomeTitularCartao { get; set; }
        public string CpfTitularCartao { get; set; }
        public string Cvv { get; set; }
        public string DataExpiracao { get; set; }

    }
}
