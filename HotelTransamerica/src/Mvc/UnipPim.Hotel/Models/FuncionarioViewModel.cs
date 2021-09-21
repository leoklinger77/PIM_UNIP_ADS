using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnipPim.Hotel.Models
{
    public class FuncionarioViewModel
    {
        public Guid CargoId { get; set; }        

        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public DateTime Nascimento { get; set; }

        public CargoViewModel Cargo { get; set; }
    }
}
