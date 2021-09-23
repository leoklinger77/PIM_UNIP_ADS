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
using UnipPim.Hotel.Dominio.Tools;
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

        [HttpGet("novo-grupo")]
        public async Task<IActionResult> NovoGrupo()
        {
            return View();
        }

        [HttpPost("novo-grupo")]
        public async Task<IActionResult> NovoGrupo(GrupoFuncionarioViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var grupo = await CriaGrupoFuncionario(viewModel);

            if(grupo is null) return View(viewModel);

            await _grupoFuncionarioServico.Insert(grupo);

            if (OperacaoValida())
            {
                return View(viewModel);
            }
            return RedirectToAction(nameof(Index));
            
        }


        [HttpGet("editar-grupo")]
        public async Task<IActionResult> EditarGrupo(Guid id)
        {
            var result = await _grupoFuncionarioServico.ObterPorId(id);

            if (OperacaoValida()) return BadRequest();

            var obj = _mapper.Map<GrupoFuncionarioViewModel>(result);

            obj.PopulaAtributos();

            return View(obj);
        }


        [HttpGet("detalhes-grupo")]
        public async Task<IActionResult> DetalhesGrupo()
        {
            return View();
        }


        [HttpGet("deletar-grupo")]
        public async Task<IActionResult> DeleteGrupo()
        {
            return View();
        }

        private async Task<GrupoFuncionario> CriaGrupoFuncionario(GrupoFuncionarioViewModel viewModel)
        {
            var newGrupo = new GrupoFuncionario(viewModel.Nome);

            string claim = string.Empty;
            foreach (var item in viewModel.Funcionario)
            {
                claim += item + ", ";
            }            
            newGrupo.AddAcesso(new Acesso("Funcionario", claim));

            claim = string.Empty;
            foreach (var item in viewModel.Hospede)
            {
                claim += item + ", ";
            }            
            newGrupo.AddAcesso(new Acesso("Hospede", claim));

            claim = string.Empty;
            foreach (var item in viewModel.Cargo)
            {
                claim += item + ", ";
            }            
            newGrupo.AddAcesso(new Acesso("Cargo", claim));

            claim = string.Empty;
            foreach (var item in viewModel.Home)
            {
                claim += item + ", ";
            }            
            newGrupo.AddAcesso(new Acesso("Home", claim));

            return newGrupo;
        }
    }
}
