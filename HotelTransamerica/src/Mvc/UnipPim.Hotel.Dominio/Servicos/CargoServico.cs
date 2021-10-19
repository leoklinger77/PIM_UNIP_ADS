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
    public class CargoServico : ServicoBase, ICargoServico
    {
        private readonly ICargoRepositorio _cargoRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public CargoServico(INotificacao notifier, ICargoRepositorio cargoRepositorio, IFuncionarioRepositorio funcionarioRepositorio) : base(notifier)
        {
            _cargoRepositorio = cargoRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public async Task<IEnumerable<Cargo>> ObterTodos()
        {
            return await _cargoRepositorio.ObterTodos();
        }

        public async Task<Cargo> ObterPorId(Guid id)
        {
            var result = await _cargoRepositorio.ObterPorId(id);
            if(result == null)
            {
                Notificar("Cargo não encontrado.");
            }
            return result;
        }

        public async Task<Paginacao<Cargo>> PaginacaoListaCargo(int page, int size, string query)
        {
            return await _cargoRepositorio.Paginacao(page, size, query);
        }

        public async Task Insert(Cargo cargo)
        {
            if (!IniciarValidacao(new CargoValidation(), cargo)) return;

            if(await _cargoRepositorio.Find(x=>x.Nome == cargo.Nome) != null)
            {
                Notificar("Cargo já existe");
                return;
            }

            await _cargoRepositorio.Insert(cargo);

            await _cargoRepositorio.SaveChanges();
            
            await Task.CompletedTask;
        }

        public async Task Update(Cargo cargo)
        {
            if (!IniciarValidacao(new CargoValidation(), cargo)) return;

            if (await _cargoRepositorio.Find(x => x.Nome == cargo.Nome) != null)
            {
                Notificar("Cargo já existe");
                return;
            }

            await _cargoRepositorio.Update(cargo);

            await _cargoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task DeletarCargo(Guid id)
        {
            var result = await ObterPorId(id);

            if(await _funcionarioRepositorio.Find(x=>x.CargoId == result.Id) != null)
            {
                Notificar("Cargo possui funcionarios. Não pode ser deletado.");
                return;
            }

            await _cargoRepositorio.Delete(result);

            await _cargoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }        
    }
}
