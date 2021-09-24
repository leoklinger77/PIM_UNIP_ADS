using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Validacoes;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class FuncionarioServico : ServicoBase, IFuncionarioServico
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public FuncionarioServico(INotificacao notifier,
                                  IFuncionarioRepositorio funcionarioRepositorio)
                                  : base(notifier)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public async Task<Funcionario> ObterPorId(Guid id)
        {
            var result = await _funcionarioRepositorio.ObterPorId(id);
            if (result == null)
            {
                Notificar("Funcionario não encontrado.");
            }
            return result;
        }

        public async Task<Paginacao<Funcionario>> PaginacaoListaFuncionario(int page, int size, string query)
        {
            return await _funcionarioRepositorio.Paginacao(page, size, query);
        }

        public async Task Insert(Funcionario funcionario)
        {
            if (await ValidaFuncionario(funcionario)) return;

            await _funcionarioRepositorio.Insert(funcionario);
            await _funcionarioRepositorio.AddTelefone(funcionario.Telefones);
            await _funcionarioRepositorio.AddEndereco(funcionario.Enderecos);
            await _funcionarioRepositorio.AddEmail(funcionario.Emails);

            await _funcionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Update(Funcionario funcionario)
        {
            if (await ValidaFuncionario(funcionario)) return;

            await _funcionarioRepositorio.Update(funcionario);
            await _funcionarioRepositorio.UpdateTelefone(funcionario.Telefones);
            await _funcionarioRepositorio.UpdateEndereco(funcionario.Enderecos);
            await _funcionarioRepositorio.UpdateEmail(funcionario.Emails);

            await _funcionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task DeletarFuncionario(Funcionario funcionario)
        {
            //TODO Validações de Chave Estrangeira do funcionario - se houve em outra tabela não pode ser deletado.

            await _funcionarioRepositorio.Delete(funcionario);
            await _funcionarioRepositorio.DeleteEmail(funcionario.Emails);
            await _funcionarioRepositorio.DeleteTelefone(funcionario.Telefones);
            await _funcionarioRepositorio.DeleteEndereco(funcionario.Enderecos);
            await _funcionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        private async Task<bool> ValidaFuncionario(Funcionario funcionario)
        {
            var fundDb = await _funcionarioRepositorio.Find(x => x.Cpf == funcionario.Cpf);
            if (fundDb != null)
            {
                if (fundDb.Id != funcionario.Id)
                {
                    Notificar("Cpf já cadastrado.");
                    return false;
                }
            }

            if (!IniciarValidacao(new FuncionarioValidation(), funcionario)) return false;

            foreach (var item in funcionario.Emails)
                if (!IniciarValidacao(new EmailValidation(), item)) return false;

            foreach (var item in funcionario.Telefones)
                if (!IniciarValidacao(new TelefoneValidation(), item)) return false;

            foreach (var item in funcionario.Enderecos)
                if (!IniciarValidacao(new EnderecoValidation(), item)) return false;

            return true;
        }
    }
}
