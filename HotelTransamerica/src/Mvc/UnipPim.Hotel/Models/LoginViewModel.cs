using System.ComponentModel.DataAnnotations;

namespace UnipPim.Hotel.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]        
        public string Password { get; set; }
    }
}
