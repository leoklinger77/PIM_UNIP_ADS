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
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Extensions.Midleware;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Authorize]
    [ClaimsAutorizacao("Quarto", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class QuartoController : MainController
    {
        private readonly IQuartoServico _quartoServico;
        private readonly IProdutoServico _produtoServico;
        public QuartoController(IMapper mapper,
                                IUser user,
                                INotificacao notificacao,
                                IQuartoServico quartoServico,
                                IProdutoServico produtoServico)
                                : base(mapper, user, notificacao)
        {
            _quartoServico = quartoServico;
            _produtoServico = produtoServico;
        }

        [HttpGet("lista-quarto")]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 8, string query = null)
        {
            var result = _mapper.Map<PaginacaoViewModel<QuartoViewModel>>(await _quartoServico.PaginacaoListaQuarto(pageIndex, pageSize, query));            
            result.ReferenceAction = "Index";
            return View(result);
        }

        [HttpGet("novo-quarto")]
        public async Task<IActionResult> NovoQuarto()
        {
            return View(new QuartoViewModel());
        }

        [HttpPost("novo-quarto")]
        public async Task<IActionResult> NovoQuarto(QuartoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            Quarto quarto = new Quarto(viewModel.Nome, viewModel.Televisor, viewModel.Hidromassagem, viewModel.Descricao, viewModel.NumeroQuarto);

            if (viewModel.CamaCasal)
                quarto.AddCama(new Cama(CamaTipo.Casal, viewModel.CamaCasalQuantidade));

            if (viewModel.CamaSolteiro)
                quarto.AddCama(new Cama(CamaTipo.Solteiro, viewModel.CamaSolteiroQuantidade));

            if (viewModel.CamaBeliche)
                quarto.AddCama(new Cama(CamaTipo.Beliche, viewModel.CamaBelicheQuantidade));

            if (quarto.Camas.Count == 0)
            {
                AddErro("Obrigatorio que seja informado 1 tipo de cama e sua quantidade.");
                return CustomView(viewModel);
            }


            await _quartoServico.Insert(quarto);

            if (OperacaoValida())
            {
                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar-quarto")]
        public async Task<IActionResult> EditarQuarto(Guid id)
        {
            var result = await _quartoServico.ObterPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(await QuartoViewModelMapping(result));
        }

        [HttpPost("editar-quarto")]
        public async Task<IActionResult> EditarQuarto(Guid id, QuartoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            Quarto quarto = _mapper.Map<Quarto>(viewModel);

            if (viewModel.CamaCasal)
                quarto.AddCama(new Cama(CamaTipo.Casal, viewModel.CamaCasalQuantidade));

            if (viewModel.CamaSolteiro)
                quarto.AddCama(new Cama(CamaTipo.Solteiro, viewModel.CamaSolteiroQuantidade));

            if (viewModel.CamaBeliche)
                quarto.AddCama(new Cama(CamaTipo.Beliche, viewModel.CamaBelicheQuantidade));

            if (quarto.Camas.Count == 0)
            {
                AddErro("Obrigatorio que seja informado 1 tipo de cama e sua quantidade.");
                return CustomView(viewModel);
            }

            await _quartoServico.Update(quarto);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes-quarto")]
        public async Task<IActionResult> DetalhesQuarto(Guid id)
        {
            var result = await _quartoServico.ObterPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(await QuartoViewModelMapping(result));
        }

        [HttpGet("delete-quarto")]
        public async Task<IActionResult> DeleteQuarto(Guid id)
        {
            var result = await _quartoServico.ObterPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<QuartoViewModel>(result));
        }

        [HttpPost("delete-quarto")]
        public async Task<IActionResult> ConfirmaDeleteQuarto(Guid id)
        {
            try
            {
                await _quartoServico.Delete(id);

                if (OperacaoValida())
                {
                    ErrosTempData();
                    return RedirectToAction(nameof(DeleteQuarto), new { id = id });
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                AddErro("Quarto não pode ser deletado pois está vinculado a um anúncio.");
                ErrosTempData();
                return RedirectToAction(nameof(DeleteQuarto), new { id = id });
            }            
        }          

        private async Task<QuartoViewModel> QuartoViewModelMapping(Quarto quarto)
        {
            QuartoViewModel viewModel = new QuartoViewModel
            {
                Descricao = quarto.Descricao,
                Nome = quarto.Nome,
                Ocupado = quarto.Ocupado,
                Televisor = quarto.Televisor,
                Id = quarto.Id,
                Hidromassagem = quarto.Hidromassagem,
                NumeroQuarto = quarto.NumeroQuarto
            };

            viewModel.ListaCama = _mapper.Map<IEnumerable<CamaViewModel>>(quarto.Camas);
            int x = 1;
            foreach (var item in quarto.Camas)
            {
                switch ((int)item.CamaTipo)
                {
                    case 1:
                        viewModel.CamaCasal = true;
                        viewModel.CamaCasalQuantidade = item.Quantidade;
                        break;
                    case 2:
                        viewModel.CamaSolteiro = true;
                        viewModel.CamaSolteiroQuantidade = item.Quantidade;
                        break;
                    case 3:
                        viewModel.CamaBeliche = true;
                        viewModel.CamaBelicheQuantidade = item.Quantidade;
                        break;
                }
                x++;
            }

            return viewModel;
        }
    }
}
