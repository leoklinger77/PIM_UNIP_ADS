using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class HospedeViewModel
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public DateTime Nascimento { get; set; }

        public IEnumerable<EmailViewModel> Emails = new List<EmailViewModel>();
        public IEnumerable<TelefoneViewModel> Telefones = new List<TelefoneViewModel>();
        public IEnumerable<EnderecoViewModel> Enderecos = new List<EnderecoViewModel>();
        public IEnumerable<DependenteViewModel> Dependentes = new List<DependenteViewModel>();
    }
    public class EmailViewModel
    {

    }
    public class TelefoneViewModel
    {

    }
    public class DependenteViewModel
    {

    }
}
