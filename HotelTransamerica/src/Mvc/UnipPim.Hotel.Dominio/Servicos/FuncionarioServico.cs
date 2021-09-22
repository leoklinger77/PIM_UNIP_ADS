using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Validacoes;
using X.PagedList;

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
            return await _funcionarioRepositorio.ObterPorId(id);
        }

        public async Task<IPagedList<Funcionario>> PaginacaoListaFuncionario(int page, int size, string query)
        {
            return await _funcionarioRepositorio.Paginacao(page, size, query);
        }

        public async Task Insert(Funcionario funcionario)
        {
            if (!IniciarValidacao(new FuncionarioValidation(), funcionario)) return;

            foreach (var item in funcionario.Emails)
            {
                if (!IniciarValidacao(new EmailValidation(), item)) return;
                await _funcionarioRepositorio.AddEmail(item);
            }

            foreach (var item in funcionario.Telefones)
            {
                if (!IniciarValidacao(new TelefoneValidation(), item)) return;
                await _funcionarioRepositorio.AddTelefone(item);
            }

            if (await _funcionarioRepositorio.Find(x=>x.Cpf == funcionario.Cpf) != null)
            {
                Notificar("Cpf já cadastrado.");
                return;
            }

            await _funcionarioRepositorio.Insert(funcionario);

            await _funcionarioRepositorio.SaveChanges();
            
            await Task.CompletedTask;
        }

        public async Task Update(Funcionario funcionario)
        {
            if (!IniciarValidacao(new FuncionarioValidation(), funcionario)) return;

            await _funcionarioRepositorio.Update(funcionario);

            await _funcionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task DeletarFuncionario(Funcionario funcionario)
        {
            //TODO Validações de Chave Estrangeira do funcionario - se houve em outra tabela não pode ser deletado.

            await _funcionarioRepositorio.Delete(funcionario);
            foreach (var item in funcionario.Emails)
            {
                await _funcionarioRepositorio.DeleteEmail(item);
            }

            foreach (var item in funcionario.Telefones)
            {
                await _funcionarioRepositorio.DeleteTelefone(item);
            }

            await _funcionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }
    }
}
