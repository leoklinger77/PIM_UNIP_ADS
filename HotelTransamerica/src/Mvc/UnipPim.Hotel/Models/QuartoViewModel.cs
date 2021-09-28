using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UnipPim.Hotel.Dominio.Models.Enum;

namespace UnipPim.Hotel.Models
{
    public class QuartoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome do quarto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Possui Televisor?")]
        public bool Televisor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Possui Hidromassagem?")]
        public bool Hidromassagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Número 0 não é permitido")]
        [Display(Name = "Número do Quarto")]
        public int NumeroQuarto { get; set; }
        public bool Ocupado { get; set; }

        //Camas
                
        [Display(Name = "Cama de Casal")]
        public bool CamaCasal { get; set; }        
        [Display(Name = "Quantidade")]
        public int CamaCasalQuantidade { get; set; }


        [Display(Name = "Cama de Solteiro")]
        public bool CamaSolteiro { get; set; }
        [Display(Name = "Quantidade")]
        public int CamaSolteiroQuantidade { get; set; }
        

        [Display(Name = "Beliche")]
        public bool CamaBeliche { get; set; }
        [Display(Name = "Quantidade")]
        public int CamaBelicheQuantidade { get; set; }


        public IEnumerable<CamaViewModel> ListaCama { get; set; }
    }

    public enum CamaTipoViewModel : int
    {
        Select = 0,
        Casal = 1,
        Solteiro = 2,
        Beliche = 3
    }
}
