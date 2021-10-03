using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Extensions.Midleware;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Authorize]
    [ClaimsAutorizacao("Hospede", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class HospedeController : MainController
    {
        private readonly IHospedeServico _hospedeServico;
        public HospedeController(IMapper mapper, IUser user, INotificacao notificacao, IHospedeServico hospedeServico) : base(mapper, user, notificacao)
        {
            _hospedeServico = hospedeServico;
        }

        [HttpGet("lista-hospede")]
        public async Task<IActionResult> Index(int page = 1, int size = 8, string query = null)
        {
            return View(_mapper.Map<PaginacaoViewModel<HospedeViewModel>>(await _hospedeServico.PaginacaoListaFuncionario(page, size, query)));
        }
    }
}
