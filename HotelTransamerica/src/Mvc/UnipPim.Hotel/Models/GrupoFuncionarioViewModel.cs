using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class GrupoFuncionarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ICollection<AcessoViewModel> Acesso { get; set; }
    }

    public class AcessoViewModel
    {
        public Guid Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
