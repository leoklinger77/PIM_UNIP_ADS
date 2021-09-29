using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    [ClaimsAutorizacao("Produto", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoServico _produtoServico;
        public ProdutoController(IMapper mapper, 
                                    IUser user, 
                                    INotificacao notificacao, 
                                    IProdutoServico produtoServico)
                                    : base(mapper, user, notificacao)
        {
            _produtoServico = produtoServico;
        }

        [HttpGet("lista-produtos")]
        public async Task<IActionResult> Index(int page = 1, int size = 8, string query = null)
        {
            return View(_mapper.Map<PaginacaoViewModel<ProdutoViewModel>>(await _produtoServico.PaginacaoListaProduto(page, size, query)));
        }

        [HttpGet("novo-produtos")]
        public async Task<IActionResult> NovoProduto()
        {
            return View(await MapearListCategoria(new ProdutoViewModel()));
        }

        [HttpPost("novo-produtos")]
        public async Task<IActionResult> NovoProduto(ProdutoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            await _produtoServico.Insert(new Produto(viewModel.Nome,viewModel.CodigoBarras,viewModel.QuantidadeEstoque, viewModel.Valor, viewModel.CategoriaId));

            if (OperacaoValida()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar-produtos")]
        public async Task<IActionResult> EditarProduto(Guid id)
        {
            var result = await _produtoServico.ObterPorId(id);

            if(result is null)
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }
            return View(await MapearListCategoria(_mapper.Map<ProdutoViewModel>(result)));
        }

        [HttpPost("editar-produtos")]
        public async Task<IActionResult> EditarProduto(Guid id, ProdutoViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return View(viewModel);

            await _produtoServico.Update(_mapper.Map<Produto>(viewModel));

            if (OperacaoValida()) return View(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes-produtos")]
        public async Task<IActionResult> DetalhesProduto(Guid id)
        {
            var result = await _produtoServico.ObterPorId(id);

            if (result is null)
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<ProdutoViewModel>(result));
        }

        [HttpGet("deletar-produtos")]
        public async Task<IActionResult> DeletarProduto(Guid id)
        {
            var result = await _produtoServico.ObterPorId(id);

            if (result is null)
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<ProdutoViewModel>(result));
        }

        [HttpPost("deletar-produtos")]
        public async Task<IActionResult> ConfirmarDeletarProduto(Guid id)
        {
            await _produtoServico.Delete(id);

            if(OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(DeletarProduto));

            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoViewModel> MapearListCategoria(ProdutoViewModel viewModel)
        {
            viewModel.ListaCategoria = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _produtoServico.ListaCategoria());
            return viewModel;
        }
    }
}
