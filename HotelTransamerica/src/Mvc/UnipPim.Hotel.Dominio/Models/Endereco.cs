using System;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Endereco : Entity
    {
        public string Cep { get; private set; }
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

        public Endereco(string cep, string logradouro, string numero, string complemento, string referencia, string bairro, Guid cidadeId)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Referencia = referencia;            
            Bairro = bairro;
            CidadeId = cidadeId;
            
        }

        public void AddFuncionario(Funcionario funcionario)
        {
            Funcionario = funcionario;
            FuncionarioId = funcionario.Id;
        }

        public void AtualizarEndereco(string cep, string logradouro, string numero, string complemento, string referencia, string bairro, Cidade cidade)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Referencia = referencia;
            Cidade = cidade;
            Bairro = bairro;
            CidadeId = cidade.Id;
        }

        public void AssociarCidade(Cidade cidade)
        {
            Cidade = cidade;
        }
    }
}
