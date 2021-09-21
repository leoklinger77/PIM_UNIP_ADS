using System;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Referencia { get; private set; }
        public string Bairro { get; private set; }
        public Cidade Cidade { get; private set; }
        public Guid CidadeId { get; private set; }

        public Funcionario Funcionario { get; private set; }
        public Guid? FuncionarioId { get; private set; }

        protected Endereco() { }

        public Endereco(string logradouro, string numero, string complemento, string referencia, string bairro, Cidade cidade)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Referencia = referencia;
            Cidade = cidade;
            Bairro = bairro;
            CidadeId = cidade.Id;
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            Funcionario = funcionario;
            FuncionarioId = funcionario.Id;
        }

        public void AtualizarEndereco(string logradouro, string numero, string complemento, string referencia, string bairro, Cidade cidade)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Referencia = referencia;
            Cidade = cidade;
            Bairro = bairro;
            CidadeId = cidade.Id;
        }
    }
}
