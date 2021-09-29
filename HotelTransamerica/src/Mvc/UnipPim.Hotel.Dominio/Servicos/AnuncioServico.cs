﻿using System;
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

        public async Task<IEnumerable<Quarto>> ListarQuartosDisponiveis()
        {
            return await _anuncioRepositorio.ObterQuartosDisponiveis();
        }

        public async Task<Anuncio> ObterPorId(Guid id)
        {
            var result = await _anuncioRepositorio.ObterPorId(id);
            if(result == null)
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
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _anuncioRepositorio.Dispose();
        }
    }
}
