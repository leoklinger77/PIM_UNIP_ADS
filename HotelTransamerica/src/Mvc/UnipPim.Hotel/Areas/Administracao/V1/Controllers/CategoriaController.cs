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

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Authorize]
    [ClaimsAutorizacao("Categoria", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaServico _categoriaServico;

        public CategoriaController(IMapper mapper,
                                    IUser user,
                                    INotificacao notificacao,
                                    ICategoriaServico categoriaServico)
                                    : base(mapper, user, notificacao)
        {
            _categoriaServico = categoriaServico;
        }

        [HttpGet("lista-Categoria")]
        public async Task<IActionResult> Index(int page = 1, int size = 8, string query = null)
        {
            var result = await _categoriaServico.PaginacaoListaCategoria(page, size, query);
            return View(_mapper.Map<PaginacaoViewModel<CategoriaViewModel>>(result));
        }

        [HttpGet("nova-categoria")]
        public async Task<IActionResult> NovaCategoria()
        {
            return View();
        }

        [HttpPost("nova-categoria")]
        public async Task<IActionResult> NovaCategoria(CategoriaViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            await _categoriaServico.Insert(new Categoria(viewModel.Nome));

            if (OperacaoValida())
            {
                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar-categoria")]
        public async Task<IActionResult> EditarCategoria(Guid id)
        {
            var result = await _categoriaServico.ObterPorId(id);

            if (result is null)
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(result);
        }

        [HttpPost("editar-categoria")]
        public async Task<IActionResult> EditarCategoria(Guid id, CategoriaViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) return View(viewModel);

            await _categoriaServico.Update(_mapper.Map<Categoria>(viewModel));

            if (OperacaoValida())
            {
                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes-categoria")]
        public async Task<IActionResult> DetalhesCategoria(Guid id)
        {
            var result = await _categoriaServico.ObterPorId(id);

            if (result is null)
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(result);
        }

        [HttpGet("deletar-categoria")]
        public async Task<IActionResult> DeletarCategoria(Guid id)
        {
            var result = await _categoriaServico.ObterPorId(id);

            if (result is null)
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(result);
        }

        [HttpPost("deletar-categoria")]
        public async Task<IActionResult> ConfirmarDeletarCategoria(Guid id)
        {
            await _categoriaServico.Delete(id);

            if (OperacaoValida()) ErrosTempData();            

            return RedirectToAction(nameof(Index));
        }
    }
}
