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
    public class CategoriaServico : ServicoBase, ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaServico(INotificacao notifier, 
            ICategoriaRepositorio categoriaRepositorio) : base(notifier)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Paginacao<Categoria>> PaginacaoListaCategoria(int page, int size, string query)
        {
            return await _categoriaRepositorio.Paginacao(page, size, query);
        }

        public async Task<Categoria> ObterPorId(Guid id)
        {
            var result = await _categoriaRepositorio.ObterPorId(id);

            if (result is null)
            {
                Notificar("Categoria não existe.");
            }

            return result;
        }

        public async Task Insert(Categoria entity)
        {
            if (!IniciarValidacao(new CategoriaValidation(), entity)) return;

            await _categoriaRepositorio.Insert(entity);

            await _categoriaRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Update(Categoria entity)
        {
            if (!IniciarValidacao(new CategoriaValidation(), entity)) return;

            await _categoriaRepositorio.Update(entity);

            await _categoriaRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Delete(Guid id)
        {
            var result = await ObterPorId(id);

            if (result is null) return;

            await _categoriaRepositorio.Delete(result);

            await _categoriaRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _categoriaRepositorio.Dispose();
        }
    }
}
