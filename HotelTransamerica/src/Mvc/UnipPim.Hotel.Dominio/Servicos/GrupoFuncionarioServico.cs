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
    public class GrupoFuncionarioServico : ServicoBase, IGrupoFuncionarioServico
    {
        private readonly IGrupoFuncionarioRepositorio _grupoFuncionarioRepositorio;
        public GrupoFuncionarioServico(INotificacao notifier, IGrupoFuncionarioRepositorio grupoFuncionarioRepositorio) : base(notifier)
        {
            _grupoFuncionarioRepositorio = grupoFuncionarioRepositorio;
        }

        public async Task<Paginacao<GrupoFuncionario>> PaginacaoGrupoFuncionario(int page, int size, string query)
        {
            return await _grupoFuncionarioRepositorio.Paginacao(page, size, query);
        }

        public async Task<GrupoFuncionario> ObterPorId(Guid id)
        {
            var grupo = await _grupoFuncionarioRepositorio.ObterPorId(id);

            if (grupo == null)
            {
                Notificar("Grupo não existe.");
                return grupo;
            }

            return grupo;
        }

        public async Task Insert(GrupoFuncionario entity)
        {
            if (await _grupoFuncionarioRepositorio.Find(x => x.Nome == entity.Nome) != null)
            {
                Notificar("Grupo já existe.");
                return;
            }

            if (!IniciarValidacao(new GrupoFuncionarioValidation(), entity)) return;

            foreach (var item in entity.Acesso)
            {
                if (!IniciarValidacao(new AcessoValidation(), item)) return;
            }

            await _grupoFuncionarioRepositorio.AddAcessoLista(entity.Acesso);

            await _grupoFuncionarioRepositorio.Insert(entity);

            await _grupoFuncionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Update(GrupoFuncionario entity)
        {
            var grupoDb = await _grupoFuncionarioRepositorio.Find(x => x.Nome == entity.Nome);
            if (grupoDb != null && grupoDb.Id != entity.Id)
            {
                Notificar("Grupo já existe.");
                return;
            }

            if (IniciarValidacao(new GrupoFuncionarioValidation(), entity)) return;

            foreach (var item in entity.Acesso)
            {
                if (IniciarValidacao(new AcessoValidation(), item)) return;
            }

            await _grupoFuncionarioRepositorio.Update(entity);

            await _grupoFuncionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Delete(Guid id)
        {
            var result =  await ObterPorId(id);

            if(result == null)
            {
                return;
            }

            await _grupoFuncionarioRepositorio.Delete(result);

            await _grupoFuncionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _grupoFuncionarioRepositorio.Dispose();
        }
    }
}
