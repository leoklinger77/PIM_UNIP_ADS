using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Models;
using X.PagedList;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class CargoController : MainController
    {
        private readonly ICargoServico _cargoServico;

        public CargoController(IMapper mapper,
                                IUser user,
                                INotificacao notificacao,
                                ICargoServico cargoServico) :
                                base(mapper, user, notificacao)
        {
            _cargoServico = cargoServico;
        }

        [HttpGet("lista-cargo")]
        public async Task<IActionResult> Index(int page = 1, int size = 8, string query = null)
        {
            IPagedList<Cargo> list = await _cargoServico.PaginacaoListaCargo(page, size, query);
            return View(list);
        }

        [HttpGet("novo-cargo")]
        public async Task<IActionResult> NovoCargo()
        {
            return View();
        }

        [HttpPost("novo-cargo")]
        public async Task<IActionResult> NovoCargo(CargoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            
            await _cargoServico.Insert(new Cargo(viewModel.Nome));

            if (OperacaoValida()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar-cargo")]
        public async Task<IActionResult> EditarCargo(Guid id)
        {
            var resultado = await ObterCargoPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<CargoViewModel>(resultado));
        }

        [HttpPost("editar-cargo")]
        public async Task<IActionResult> EditarCargo(Guid id, CargoViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            await _cargoServico.Update(_mapper.Map<Cargo>(viewModel));

            if (OperacaoValida()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes-cargo")]
        public async Task<IActionResult> DetalhesCargo(Guid id)
        {
            var resultado = await ObterCargoPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<CargoViewModel>(resultado));
        }

        [HttpGet("deletar-cargo")]
        public async Task<IActionResult> DeletarCargo(Guid id)
        {
            var resultado = await ObterCargoPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<CargoViewModel>(resultado));
        }

        [HttpPost("deletar-cargo")]
        public async Task<IActionResult> ConfirmaDeletarCargo(Guid id)
        {
            var resultado = await ObterCargoPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            await _cargoServico.DeletarCargo(resultado);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<Cargo> ObterCargoPorId(Guid id)
        {
            if (Guid.Empty == id)
            {
                AddErro("Cargo não existe.");
                return null;
            }

            var resultado = await _cargoServico.ObterPorId(id);

            if (resultado == null)
            {
                AddErro("Cargo não existe.");
                return null;
            }

            return resultado;
        }
    }
}
