using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Validacoes;
using X.PagedList;

namespace UnipPim.Hotel.Dominio.Servicos
{
    public class CargoServico : ServicoBase, ICargoServico
    {
        private readonly ICargoRepositorio _cargoRepositorio;        

        public CargoServico(INotificacao notifier, ICargoRepositorio cargoRepositorio) : base(notifier)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        public Task<Cargo> ObterPorId(Guid id)
        {
            return _cargoRepositorio.ObterPorId(id);
        }

        public async Task<IPagedList<Cargo>> PaginacaoListaCargo(int page, int size, string query)
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

            await _cargoRepositorio.Update(cargo);

            await _cargoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }

        public async Task DeletarCargo(Cargo resultado)
        {
            //TODO Verificar se possui funcionarios - caso possuia não pode ser deletado;

            await _cargoRepositorio.Delete(resultado);

            await _cargoRepositorio.SaveChanges();

            await Task.CompletedTask;
        }
    }
}
