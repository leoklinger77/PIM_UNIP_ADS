using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
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
            await _grupoFuncionarioRepositorio.Insert(entity);

            await _grupoFuncionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Update(GrupoFuncionario entity)
        {
            await _grupoFuncionarioRepositorio.Update(entity);

            await _grupoFuncionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Delete(GrupoFuncionario entity)
        {
            await _grupoFuncionarioRepositorio.Delete(entity);

            await _grupoFuncionarioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _grupoFuncionarioRepositorio.Dispose();
        }
    }
}
