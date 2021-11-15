using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Areas.Api.V1.Controllers
{
    [Authorize]
    [ApiController]
    [Area("Api")]
    [Route("Api/V1/[controller]")]
    public class CaixaController : ApiController
    {
        private readonly ICaixaServico _caixaServico;
        private readonly IProdutoServico _produtoServico;
        public CaixaController(IMapper mapper,
                                IUser user,
                                INotificacao notificacao,
                                ICaixaServico caixaServico,
                                IProdutoServico produtoServico)
                                : base(mapper, user, notificacao)
        {
            _caixaServico = caixaServico;
            _produtoServico = produtoServico;
        }

        [HttpGet("obterCaixa")]
        public async Task<IActionResult> GetCaixa()
        {
            var result = await _caixaServico.ObterCaixa(_user.UserId);

            if (OperacaoValida()) return CustomResponse();

            return CustomResponse(result);
        }

        [HttpGet("Abrircaixa/{value:decimal}")]
        public async Task<IActionResult> GetAbrirCaixa(decimal value)
        {
            await _caixaServico.AbrirCaixa(_user.UserId, value);

            if (OperacaoValida()) return CustomResponse();

            return CustomResponse();
        }

        [HttpGet("FecharCaixa")]
        public async Task<IActionResult> GetFecharCaixa()
        {
            await _caixaServico.FecharCaixa(_user.UserId);

            if (OperacaoValida()) return CustomResponse();

            return CustomResponse();
        }

        [HttpGet("produto/{codeBarras}")]
        public async Task<ActionResult> GetProduto(string codeBarras)
        {
            if (string.IsNullOrEmpty(codeBarras))
            {
                return BadRequest();
            }

            var produto = await _produtoServico.ObterPorCodigoDeBarras(codeBarras);

            if (OperacaoValida()) return CustomResponse();

            return CustomResponse(_mapper.Map<ProdutoViewModel>(produto));
        }

        [HttpPost("order-venda")]
        public async Task<IActionResult> GetAbrirOrderVenda(AbrirOrderVendaViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var orderVenda = await _caixaServico.IniciarOrderDeVenda(_user.UserId, viewModel.Cpf);

            if (OperacaoValida()) return CustomResponse();

            return CustomResponse(_mapper.Map<OrderVendaViewModel>(orderVenda));
        }

        [HttpGet("add-produto")]
        public async Task<IActionResult> GetAddProdutoOrder(Guid orderVendaId, Guid produtoId, int quantidade)
        {
            if (Guid.Empty == orderVendaId || Guid.Empty == produtoId || quantidade <= 0)
            {
                return BadRequest();
            }

            await _caixaServico.AddProdutoNaOrder(_user.UserId, orderVendaId, produtoId, quantidade);

            if (OperacaoValida()) return CustomResponse();

            return CustomResponse();
        }

        [HttpGet("update-produto")]
        public async Task<IActionResult> GetUpdateProdutoOrder(Guid orderVendaId, Guid produtoId, int quantidade)
        {
            if (Guid.Empty == orderVendaId || Guid.Empty == produtoId || quantidade <= 0)
            {
                return BadRequest();
            }

            await _caixaServico.UpdateProdutoNaOrder(_user.UserId, orderVendaId, produtoId, quantidade);

            if (OperacaoValida()) return CustomResponse();

            return CustomResponse();
        }

        [HttpGet("remover-produto")]
        public async Task<IActionResult> GetRemoverProdutoOrder(Guid orderVendaId, Guid produtoId)
        {
            if (Guid.Empty == orderVendaId || Guid.Empty == produtoId)
            {
                return BadRequest();
            }

            await _caixaServico.RemoverProdutoNaOrder(_user.UserId, orderVendaId, produtoId);

            if (OperacaoValida()) return CustomResponse();

            return CustomResponse();
        }
    }
}
