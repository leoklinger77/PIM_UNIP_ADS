using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Dominio.Tools;
using UnipPim.Hotel.Extensions.Midleware;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Authorize]
    [ClaimsAuthorize("Quarto", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class QuartoController : MainController
    {
        private readonly IQuartoServico _quartoServico;
        public QuartoController(IMapper mapper, 
                                IUser user, 
                                INotificacao notificacao, 
                                IQuartoServico quartoServico)
                                : base(mapper, user, notificacao)
        {
            _quartoServico = quartoServico;
        }

        [HttpGet("lista-quarto")]
        public async Task<IActionResult> Index(int page = 1, int size = 8, string query = null)
        {
            var result = await _quartoServico.PaginacaoListaQuarto(page, size, query);
            return View(_mapper.Map<PaginacaoViewModel<QuartoViewModel>>(result));
        }

        [HttpGet("novo-quarto")]
        public async Task<IActionResult> NovoQuarto()
        {
            return View();
        }

        [HttpPost("novo-quarto")]
        public async Task<IActionResult> NovoQuarto(QuartoViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            Quarto quarto = new Quarto(viewModel.Nome, viewModel.Televisor, viewModel.Hidromassagem, viewModel.Descricao, viewModel.NumeroQuarto);            
            quarto.AddCama(new Cama(viewModel.CamaTipoUm, viewModel.QuantidadeCamaUm));
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
            var result =  await _quartoServico.ObterPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(result);
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

            return View(result);
        }
        
        [HttpPost("delete-quarto")]
        public async Task<IActionResult> DeleteQuarto(Guid id)
        {
            await _quartoServico.Delete(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
