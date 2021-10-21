using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Validacoes;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class AnuncioServico : ServicoBase, IAnuncioServico
    {
        private readonly IAnuncioRepositorio _anuncioRepositorio;

        public AnuncioServico(INotificacao notificacao,
                                IAnuncioRepositorio anuncioRepositorio)
                                : base(notificacao)
        {
            _anuncioRepositorio = anuncioRepositorio;
        }

        public async Task<Paginacao<Anuncio>> PaginacaoListaAnuncio(int page, int size, string query)
            => await _anuncioRepositorio.Paginacao(page, size, query);

        public async Task<IEnumerable<Anuncio>> TresAnunciosAleatorios() 
            => await _anuncioRepositorio.TresAnunciosAleatorios();

        public async Task<IEnumerable<Quarto>> ListarQuartosDisponiveis()
        {
            return await _anuncioRepositorio.ObterQuartosDisponiveis();
        }

        public async Task<Anuncio> ObterPorId(Guid id)
        {
            var result = await _anuncioRepositorio.ObterPorId(id);
            if (result == null)
            {
                Notificar("Anuncio não encontrado.");
            }
            return result;
        }

        public async Task Insert(Anuncio entity)
        {
            if (!IniciarValidacao(new AnuncioValidation(), entity)) return;
            foreach (var item in entity.Fotos)
            {
                if (!IniciarValidacao(new FotoValidation(), item)) return;
                await _anuncioRepositorio.AddFoto(item);
            }

            await _anuncioRepositorio.Insert(entity);

            await _anuncioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Update(Anuncio entity)
        {
            if (!IniciarValidacao(new AnuncioValidation(), entity)) return;
            foreach (var item in entity.Fotos) if (!IniciarValidacao(new FotoValidation(), item)) return;

            var anuncioDb = await ObterPorId(entity.Id);

            foreach (var item in anuncioDb.Fotos.Except(entity.Fotos))
            {
                await _anuncioRepositorio.DeleteFoto(item);
            }

            foreach (var item in entity.Fotos)
            {
                if(anuncioDb.Fotos.Where(x => x.Caminho == item.Caminho) == null)               
                {
                    anuncioDb.AddFoto(item);
                    await _anuncioRepositorio.AddFoto(item);
                }                
            }
                       

            if (entity.Ativo)
                anuncioDb.AtivarAnuncio();
            else
                anuncioDb.DesativarAnuncio();

            if (anuncioDb.Quantidade != entity.Quantidade)
                anuncioDb.SetQuantidade(entity.Quantidade);

            if (anuncioDb.Nome != entity.Nome)
                anuncioDb.SetNome(entity.Nome);

            if (anuncioDb.Custo != entity.Custo)
                anuncioDb.SetCusto(entity.Custo);

            if (anuncioDb.QuartoId != entity.QuartoId)
                anuncioDb.SetQuartoId(entity.QuartoId);


            await _anuncioRepositorio.Update(anuncioDb);

            await _anuncioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Delete(Guid id)
        {
            var anuncio = await ObterPorId(id);

            foreach (var item in anuncio.Fotos)
            {
                await _anuncioRepositorio.DeleteFoto(item);
            }

            await _anuncioRepositorio.Delete(anuncio);

            await _anuncioRepositorio.SaveChanges();

            await Task.CompletedTask;
        }
        public void Dispose()
        {
            _anuncioRepositorio.Dispose();
        }
    }
}
