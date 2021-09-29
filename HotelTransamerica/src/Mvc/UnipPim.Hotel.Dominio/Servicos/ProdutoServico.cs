using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Validacoes;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class ProdutoServico : ServicoBase, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public ProdutoServico(INotificacao notifier,
                                IProdutoRepositorio produtoRepositorio, ICategoriaRepositorio categoriaRepositorio)
                                : base(notifier)
        {
            _produtoRepositorio = produtoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
        }
        public async Task<IEnumerable<Categoria>> ListaCategoria()
        {
            return await _categoriaRepositorio.ObterTodos();
        }

        public async Task<Paginacao<Produto>> PaginacaoListaProduto(int page, int size, string query)
        {
            return await _produtoRepositorio.Paginacao(page, size, query);
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            var result = await _produtoRepositorio.ObterPorId(id);

            if (result is null)
            {
                Notificar("Produto não encontrado.");
            }
            return result;
        }

        public async Task Insert(Produto entity)
        {
            if (await _produtoRepositorio.Find(x => x.CodigoBarras == entity.CodigoBarras) != null)
            {
                Notificar("Codigo de barras já cadastado para outro produto.");
                return;
            }

            if (!IniciarValidacao(new ProdutoValidation(), entity)) return;

            await _produtoRepositorio.Insert(entity);

            await _produtoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Update(Produto entity)
        {
            var result = await _produtoRepositorio.Find(x => x.CodigoBarras == entity.CodigoBarras);

            if (result.Id != entity.Id)
            {
                Notificar("Codigo de barras já cadastado para outro produto.");
                return;
            }

            if (!IniciarValidacao(new ProdutoValidation(), entity)) return;

            await _produtoRepositorio.Update(entity);

            await _produtoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Delete(Guid id)
        {
            var result = await ObterPorId(id);

            if (result is null) return;

            await _produtoRepositorio.Delete(result);

            await _produtoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _produtoRepositorio.Dispose();
        }

        
    }
}
