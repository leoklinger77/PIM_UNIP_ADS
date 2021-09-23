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
    [ClaimsAuthorize("GrupoFuncionario", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class GrupoFuncionarioController : MainController
    {
        private readonly IGrupoFuncionarioServico _grupoFuncionarioServico;
        public GrupoFuncionarioController(IMapper mapper, 
                                            IUser user, 
                                            INotificacao notificacao, 
                                            IGrupoFuncionarioServico grupoFuncionarioServico)
                                            : base(mapper, user, notificacao)
        {
            _grupoFuncionarioServico = grupoFuncionarioServico;
        }

        [HttpGet("listra-grupos-funcionario")]
        public async Task<IActionResult> Index(int page = 1, int size = 8, string query = null)
        {            
            return View(_mapper.Map<PaginacaoViewModel<GrupoFuncionarioViewModel>>(await _grupoFuncionarioServico.PaginacaoGrupoFuncionario(page, size, query)));
        }
    }
}
