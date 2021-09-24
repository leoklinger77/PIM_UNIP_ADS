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
    public class QuartoServico : ServicoBase, IQuartoServico
    {
        private readonly IQuartoRepositorio _quartoRepositorio;

        public QuartoServico(INotificacao notificacao, IQuartoRepositorio quartoRepositorio) : base(notificacao)
        {
            _quartoRepositorio = quartoRepositorio;
        }

        public async Task<Paginacao<Quarto>> PaginacaoListaQuarto(int page, int size, string query) 
            => await _quartoRepositorio.Paginacao(page, size, query);


        public async Task<Quarto> ObterPorId(Guid id)
        {
            var result = await _quartoRepositorio.ObterPorId(id);

            if(result is null)
            {
                Notificar("Quarto não existe.");
                return result;
            }

            return result;
        }

        public async Task Insert(Quarto entity)
        {
            if (await _quartoRepositorio.Find(x=>x.NumeroQuarto == entity.NumeroQuarto) != null)
            {
                Notificar("Número do quarto já existe.");
                return;
            }

            if (!IniciarValidacao(new QuartoValidation(), entity)) return;

            foreach (var item in entity.Camas)
            {
                if (!IniciarValidacao(new CamaValidation(), item)) return;
            }

            await _quartoRepositorio.Insert(entity);
            await _quartoRepositorio.AddCama(entity.Camas);

            await _quartoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }


        public async Task Update(Quarto entity)
        {
            if (!IniciarValidacao(new QuartoValidation(), entity)) return;

            var quartoDb = await _quartoRepositorio.Find(x => x.NumeroQuarto == entity.NumeroQuarto);
            if (quartoDb != null && quartoDb.Id != entity.Id)
            {
                Notificar("Número do quarto já existe.");
                return;
            }

            await _quartoRepositorio.Insert(entity);

            await _quartoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task Delete(Guid id)
        {
            var result = await ObterPorId(id);

            if (result == null)
            {
                return;
            }

            await _quartoRepositorio.Insert(result);

            await _quartoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _quartoRepositorio.Dispose();
        }

       
    }
}
