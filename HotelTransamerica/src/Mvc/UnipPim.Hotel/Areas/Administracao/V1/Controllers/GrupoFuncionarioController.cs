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
    [ClaimsAutorizacao("GrupoFuncionario", "Home")]
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
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 8, string query = null)
        {
            var result = _mapper.Map<PaginacaoViewModel<GrupoFuncionarioViewModel>>(await _grupoFuncionarioServico.PaginacaoGrupoFuncionario(pageIndex, pageSize, query));
            result.ReferenceAction = "Index";
            return View(result);
        }

        [HttpGet("novo-grupo")]
        [ClaimsAutorizacao("GrupoFuncionario", "Novo")]
        public async Task<IActionResult> NovoGrupo()
        {
            return View();
        }

        [HttpPost("novo-grupo")]
        [ClaimsAutorizacao("GrupoFuncionario", "Novo")]
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
        [ClaimsAutorizacao("GrupoFuncionario", "Editar")]
        public async Task<IActionResult> EditarGrupo(Guid id)
        {
            var result = await _grupoFuncionarioServico.ObterPorId(id);

            if (OperacaoValida()) return BadRequest();

            var obj = _mapper.Map<GrupoFuncionarioViewModel>(result);

            obj.PopulaAtributos();

            return View(obj);
        }

        [HttpGet("detalhes-grupo")]
        [ClaimsAutorizacao("GrupoFuncionario", "Detalhes")]
        public async Task<IActionResult> DetalhesGrupo(Guid id)
        {
            var result = await _grupoFuncionarioServico.ObterPorId(id);

            if (OperacaoValida()) return BadRequest();

            var obj = _mapper.Map<GrupoFuncionarioViewModel>(result);

            obj.PopulaAtributos();

            return View(obj);
        }

        [HttpGet("deletar-grupo")]
        [ClaimsAutorizacao("GrupoFuncionario", "Delete")]
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
