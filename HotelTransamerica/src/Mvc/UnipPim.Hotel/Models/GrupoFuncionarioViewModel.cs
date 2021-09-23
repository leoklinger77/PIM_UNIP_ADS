using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class GrupoFuncionarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }


        public List<string> Funcionario { get; set; } = new List<string>();
        public List<string> Hospede { get; set; } = new List<string>();
        public List<string> Cargo { get; set; } = new List<string>();
        public List<string> Home { get; set; } = new List<string>();



        public ICollection<AcessoViewModel> Acesso { get; set; } = new List<AcessoViewModel>();


        public GrupoFuncionarioViewModel()
        {
        }

        internal void PopulaAtributos()
        {
            foreach (var item in Acesso)
            {
                string[] claims = item.ClaimValue.Split(',');
                switch (item.ClaimType)
                {
                    case "Funcionario":
                        foreach (var claim in claims)
                        {
                            Funcionario.Add(claim);
                        }
                        break;                   

                    case "Cargo":
                        foreach (var claim in claims)
                        {
                            Cargo.Add(claim);
                        }
                        break;

                    case "Hospede":
                        foreach (var claim in claims)
                        {
                            Hospede.Add(claim);
                        }
                        break;

                    case "Home":
                        foreach (var claim in claims)
                        {
                            Home.Add(claim.ToString());
                        }
                        break;                   
                }
            }
        }
    }

    public class AcessoViewModel
    {
        public Guid Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
