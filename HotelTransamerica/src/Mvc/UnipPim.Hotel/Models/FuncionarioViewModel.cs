using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UnipPim.Hotel.Extensions.DataAnnotations;

namespace UnipPim.Hotel.Models
{
    public class FuncionarioViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name ="Cargo")]
        public Guid CargoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Grupo Funcionario")]
        public Guid GrupoFuncionarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome Completo")]
        [NomeCompleto]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo {0} deve conter {1} números", MinimumLength = 11)]
        [Cpf]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Nascimento]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage ="E-mail é inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(10, ErrorMessage = "O campo {0} deve conter {1} números", MinimumLength = 10)]
        [Display(Name = "Telefone Fixo")]
        [Fixo]
        public string TelefoneFixo { get; set; }
        public Guid TelefoneFixoID { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo {0} deve conter {1} números", MinimumLength = 11)]
        [Display(Name = "Telefone Celular")]
        [Celular]
        public string TelefoneCelular { get; set; }
        public Guid TelefoneCelularId { get; set; }


        public EnderecoViewModel Endereco { get; set; }
        public CargoViewModel Cargo { get; set; }
        public GrupoFuncionarioViewModel GrupoFuncionario { get; set; }

        public IEnumerable<CargoViewModel> ListaCargo { get; set; }
        public IEnumerable<GrupoFuncionarioViewModel> ListaGrupoFuncionario { get; set; }
    }
}
