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


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Primeiro Cama")]
        public CamaTipo CamaTipoUm { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Quantidade")]
        public int QuantidadeCamaUm { get; set; }


        [Display(Name = "Segunda Cama")]
        public string CamaTipoDois { get; set; }
        [Display(Name = "Quantidade")]
        public string QuantidadeCamaDois { get; set; }
        

        [Display(Name = "Terceira Cama")]
        public string CamaTipoTres { get; set; }
        [Display(Name = "Quantidade")]
        public string QuantidadeCamaTres { get; set; }


        public IEnumerable<CamaViewModel> ListaCama { get; set; }
    }
}
