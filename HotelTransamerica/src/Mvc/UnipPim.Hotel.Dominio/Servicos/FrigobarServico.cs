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
    public class FrigobarServico : ServicoBase, IFrigobarServico
    {
        private readonly IFrigobarRepositorio _frigobarRepositorio;
        public FrigobarServico(INotificacao notifier, 
                                IFrigobarRepositorio frigobarRepositorio) 
                                : base(notifier)
        {
            _frigobarRepositorio = frigobarRepositorio;
        }

        public async Task<Paginacao<ProdutosFrigobar>> PaginacaoProdutos(int page, int size, string query)
        {
            return await _frigobarRepositorio.PaginacaoProdutos(page, size, query);
        }

        public async Task<Paginacao<ProdutosConsumidos>> PaginacaoProdutosConsumidos(int page, int size, string query)
        {
            return await _frigobarRepositorio.PaginacaoProdutosConsumidos(page, size, query);
        }

        public async Task<Frigobar> ObterPorId(Guid id)
        {
            var result = await _frigobarRepositorio.ObterPorId(id);
            
            if(result is null)
            {
                Notificar("Frigobar não encontrado.");
            }
            return result;
        }

        public async Task Insert(Frigobar entity)
        {
            if (IniciarValidacao(new FrigobarValidation(), entity)) return;
        }        

        public async Task Update(Frigobar entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoverProduto(ProdutosFrigobar produtos)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
