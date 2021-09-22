using System;
using System.ComponentModel.DataAnnotations;

namespace UnipPim.Hotel.Models
{
    public class CargoViewModel
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }
    }
}
