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
    public class HospedeServico : ServicoBase, IHospedeServico
    {
        private readonly IHospedeRepositorio _hospedeRepositorio;

        public HospedeServico(INotificacao notificacao, IHospedeRepositorio hospedeRepositorio) : base(notificacao)
        {
            _hospedeRepositorio = hospedeRepositorio;
        }

        public async Task<Hospede> ObterPorId(Guid id)
        {
            var hospede = await _hospedeRepositorio.ObterPorId(id);

            if(hospede == null)
            {
                Notificar("Hospede não encontrado.");
                return hospede;
            }

            return hospede;
        }

        public async Task<Paginacao<Hospede>> PaginacaoListaFuncionario(int page, int size, string query)
        {
            return await _hospedeRepositorio.Paginacao(page, size, query);
        }

        public async Task Insert(Hospede hospede)
        {
            if (await _hospedeRepositorio.Find(x=>x.Cpf == hospede.Cpf) != null)
            {
                Notificar("Cpf já cadastrado.");
                return;
            }

            if (!IniciarValidacao(new HospedeValidation(), hospede)) return;

            foreach (var item in hospede.Emails)
            {
                if (!IniciarValidacao(new EmailValidation(), item)) return;
                await _hospedeRepositorio.AddEmail(item);
            }

            foreach (var item in hospede.Telefones)
            {
                if (!IniciarValidacao(new TelefoneValidation(), item)) return;
                await _hospedeRepositorio.AddTelefone(item);
            }

            await _hospedeRepositorio.Insert(hospede);

            await _hospedeRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Update(Hospede hospede)
        {
            if (!IniciarValidacao(new HospedeValidation(), hospede)) return;
            
            await _hospedeRepositorio.Insert(hospede);

            await _hospedeRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Deletar(Hospede hospede)
        {
            await _hospedeRepositorio.Delete(hospede);

            await _hospedeRepositorio.SaveChanges();

            await Task.CompletedTask;
        }
    }
}
