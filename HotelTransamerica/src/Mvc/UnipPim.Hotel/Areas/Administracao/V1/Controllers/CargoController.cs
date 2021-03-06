using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Extensions.Midleware;
using UnipPim.Hotel.Models;
using X.PagedList;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Authorize]
    [ClaimsAutorizacao("Cargo", "Home")]
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
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 8, string query = null)
        {
            var result = _mapper.Map<PaginacaoViewModel<CargoViewModel>>(await _cargoServico.PaginacaoListaCargo(pageIndex, pageSize, query));
            result.ReferenceAction = "Index";
            return View(result);
        }

        [HttpGet("novo-cargo")]
        [ClaimsAutorizacao("Cargo", "Novo")]
        public async Task<IActionResult> NovoCargo()
        {
            return View();
        }

        [HttpPost("novo-cargo")]
        [ClaimsAutorizacao("Cargo", "Novo")]
        public async Task<IActionResult> NovoCargo(CargoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            
            await _cargoServico.Insert(new Cargo(viewModel.Nome));

            if (OperacaoValida()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar-cargo")]
        [ClaimsAutorizacao("Cargo", "Editar")]
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
        [ClaimsAutorizacao("Cargo", "Editar")]
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
        [ClaimsAutorizacao("Cargo", "Detalhes")]
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
        [ClaimsAutorizacao("Cargo", "Deletar")]
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
        [ClaimsAutorizacao("Cargo", "Deletar")]
        public async Task<IActionResult> ConfirmaDeletarCargo(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            await _cargoServico.DeletarCargo(id);

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
