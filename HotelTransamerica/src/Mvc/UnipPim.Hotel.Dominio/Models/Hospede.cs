using System;
using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Dominio.Models
{
    public class Hospede : Entity, IAggregateRoot
    {
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public DateTime Nascimento { get; private set; }        

        private List<Email> _emails = new List<Email>();
        private List<Telefone> _telefones = new List<Telefone>();
        private List<Endereco> _enderecos = new List<Endereco>();

        public IReadOnlyCollection<Email> Emails => _emails;
        public IReadOnlyCollection<Telefone> Telefones => _telefones;
        public IReadOnlyCollection<Endereco> Enderecos => _enderecos;

        protected Hospede() { }

        public Hospede(string nomeCompleto, string cpf, DateTime nascimento)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            Nascimento = nascimento;            
        }

        public void SetNomeCompleto(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
        }

        public void AddEmail(Email email)
        {
            _emails.Add(email);
        }

        public void AddTelefone(Telefone telefone)
        {
            _telefones.Add(telefone);
        }

        public void AddEndereco(Endereco endereco)
        {
            _enderecos.Add(endereco);
        }

    }
}
