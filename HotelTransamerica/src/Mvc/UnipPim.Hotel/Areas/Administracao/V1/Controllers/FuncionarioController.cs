using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Dominio.Tools;
using UnipPim.Hotel.Extensions.Midleware;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Authorize]
    [ClaimsAutorizacao("Funcionario", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class FuncionarioController : MainController
    {
        private readonly IFuncionarioServico _funcionarioServico;
        private readonly IGrupoFuncionarioRepositorio _grupoFuncionarioRepositorio;
        private readonly ICargoServico _cargoServico;
        private readonly IEstadoServico _estadoServico;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public FuncionarioController(IMapper mapper,
                                IUser user,
                                INotificacao notificacao,
                                IFuncionarioServico funcionarioServico,
                                UserManager<IdentityUser> userManager,
                                ICargoServico cargoServico,
                                IEmailSender emailSender,
                                IEstadoServico estadoServico,
                                IGrupoFuncionarioRepositorio grupoFuncionarioRepositorio) :
                                base(mapper, user, notificacao)
        {
            _funcionarioServico = funcionarioServico;
            _userManager = userManager;
            _cargoServico = cargoServico;
            _emailSender = emailSender;
            _estadoServico = estadoServico;
            _grupoFuncionarioRepositorio = grupoFuncionarioRepositorio;
        }

        [HttpGet("lista-Funcionario")]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 8, string query = null)
        {
            var result = _mapper.Map<PaginacaoViewModel<FuncionarioViewModel>>(await _funcionarioServico.PaginacaoListaFuncionario(pageIndex, pageSize, query));
            result.ReferenceAction = "Index";
            return View(result);
        }

        [HttpGet("novo-Funcionario")]
        [ClaimsAutorizacao("Funcionario", "Novo")]
        public async Task<IActionResult> NovoFuncionario()
        {
            return View(await PopulaListaCargoEGrupos(new FuncionarioViewModel()));
        }

        [HttpPost("novo-Funcionario")]
        [ClaimsAutorizacao("Funcionario", "Novo")]
        public async Task<IActionResult> NovoFuncionario(FuncionarioViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(await PopulaListaCargoEGrupos(viewModel));

            var newFuncionario = await CriarFuncionario(viewModel);
            await _funcionarioServico.Insert(newFuncionario);

            if (OperacaoValida()) return View(await PopulaListaCargoEGrupos(viewModel));

            if (!await CriarLoginFuncionario(newFuncionario.Id, viewModel.Email, viewModel.GrupoFuncionarioId))
            {
                await _funcionarioServico.DeletarFuncionario(newFuncionario.Id);
                return View(await PopulaListaCargoEGrupos(viewModel));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar-Funcionario")]
        [ClaimsAutorizacao("Funcionario", "Editar")]
        public async Task<IActionResult> EditarFuncionario(Guid id)
        {
            var resultado = await ObterFuncionarioPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(await PopulaListaCargoEGrupos(await PopulaFuncionario(resultado)));
        }

        [HttpPost("editar-Funcionario")]
        [ClaimsAutorizacao("Funcionario", "Editar")]
        public async Task<IActionResult> EditarFuncionario(Guid id, FuncionarioViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            var funcDb = await ObterFuncionarioPorId(id);
            viewModel.Cpf = funcDb.Cpf;
            viewModel.Nascimento = funcDb.Nascimento;

            await _funcionarioServico.Update(_mapper.Map<Funcionario>(viewModel));

            if (OperacaoValida()) return View(await PopulaListaCargoEGrupos(viewModel));

            await UpdateClaimsFunciorio(viewModel.Email, viewModel.GrupoFuncionarioId);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes-Funcionario")]
        [ClaimsAutorizacao("Funcionario", "Detalhes")]
        public async Task<IActionResult> DetalhesFuncionario(Guid id)
        {
            var resultado = await ObterFuncionarioPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }
            return View(await PopulaFuncionario(resultado));
        }

        [HttpGet("deletar-Funcionario")]
        [ClaimsAutorizacao("Funcionario", "Deletar")]
        public async Task<IActionResult> DeletarFuncionario(Guid id)
        {
            var resultado = await ObterFuncionarioPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }
            return View(await PopulaListaCargoEGrupos(await PopulaFuncionario(resultado)));
        }

        [HttpPost("deletar-Funcionario")]
        [ClaimsAutorizacao("Funcionario", "Deletar")]
        public async Task<IActionResult> ConfirmaDeletarFuncionario(Guid id)
        {
            if(id == _user.UserId)
            {
                AddErro("Não é possivel excluir um usuario que está logado.");
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }          

            await _funcionarioServico.DeletarFuncionario(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }
            
            await DeletarLoginFuncionario(ObterFuncionarioPorId(id).Result.Emails.First().EnderecoEmail);

            return RedirectToAction(nameof(Index));
        }

        private async Task<Funcionario> ObterFuncionarioPorId(Guid id)
        {
            if (Guid.Empty == id)
            {
                AddErro("Funcionario não existe.");
                return null;
            }

            var resultado = await _funcionarioServico.ObterPorId(id);

            if (resultado == null)
            {
                AddErro("Funcionario não existe.");
                return null;
            }

            return resultado;
        }

        private async Task<Funcionario> CriarFuncionario(FuncionarioViewModel viewModel)
        {
            var newfuncionario = new Funcionario(viewModel.NomeCompleto, viewModel.Cpf, viewModel.Nascimento, viewModel.CargoId, viewModel.GrupoFuncionarioId);

            newfuncionario.AddEmail(new Email(viewModel.Email, EmailTipo.COMERCIAL));

            newfuncionario.AddTelefone(new Telefone(viewModel.TelefoneCelular.Substring(0, 2), viewModel.TelefoneCelular.Substring(2), TelefoneTipo.CELULAR));

            if (!string.IsNullOrEmpty(viewModel.TelefoneFixo))
                newfuncionario.AddTelefone(new Telefone(viewModel.TelefoneFixo.Substring(0, 2), viewModel.TelefoneFixo.Substring(2), TelefoneTipo.RESIDENCIAL));

            var cidade = await _estadoServico.ObterCidadeComEstado(viewModel.Endereco.Cidade, viewModel.Endereco.Estado);

            newfuncionario.AddEndereco(new Endereco(viewModel.Endereco.Cep,
                                                    viewModel.Endereco.Logradouro,
                                                    viewModel.Endereco.Numero,
                                                    viewModel.Endereco.Complemento,
                                                    viewModel.Endereco.Referencia,
                                                    viewModel.Endereco.Cidade,
                                                    cidade.Id));
            return newfuncionario;
        }

        private async Task<bool> CriarLoginFuncionario(Guid funcionarioId, string email, Guid grupoFuncionario)
        {
            var user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = false, Id = funcionarioId.ToString() };
            var password = CodeGeneretor.GerarSenha(20);
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (!await CriarClaimsFunciorio(user, grupoFuncionario))
                {
                    await DeletarLoginFuncionario(email, user);
                    return false;
                }

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = user.Id, code = code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(email, "Confirmar seu e-mail",
                    $"Por favor, confirme sua conta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicando aqui</a>. " +
                    $"<br/>" +
                    $"Sua senha é: {password} <br/>");

                return true;
            }
            foreach (var error in result.Errors)
            {
                AddErro(error.Description);
            }
            return false;
        }

        private async Task<bool> DeletarLoginFuncionario(string email, IdentityUser user = null)
        {
            if (user != null)
            {
                user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    AddErro("User Login não encontrado.");
                    return false;
                }
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return true;
            }
            foreach (var error in result.Errors)
            {
                AddErro(error.Description);
            }
            return false;
        }

        private async Task<FuncionarioViewModel> PopulaListaCargoEGrupos(FuncionarioViewModel viewModel)
        {
            viewModel.ListaCargo = _mapper.Map<IEnumerable<CargoViewModel>>(await _cargoServico.ObterTodos());
            viewModel.ListaGrupoFuncionario = _mapper.Map<IEnumerable<GrupoFuncionarioViewModel>>(await _grupoFuncionarioRepositorio.ObterTodos());
            return viewModel;
        }

        private async Task<FuncionarioViewModel> PopulaFuncionario(Funcionario func)
        {
            var viewModel = _mapper.Map<FuncionarioViewModel>(func);
            viewModel.Email = func.Emails.First().EnderecoEmail;
            foreach (var item in func.Enderecos)
            {
                viewModel.Endereco = _mapper.Map<EnderecoViewModel>(item);
            }
            foreach (var item in func.Telefones)
            {
                if (item.TelefoneTipo == TelefoneTipo.CELULAR)
                {
                    viewModel.TelefoneCelular = item.Ddd + item.Numero;
                }
                else if (item.TelefoneTipo == TelefoneTipo.RESIDENCIAL)
                {
                    viewModel.TelefoneFixo = item.Ddd + item.Numero;
                }

            }
            return viewModel;
        }

        private async Task<bool> CriarClaimsFunciorio(IdentityUser user, Guid grupoFuncionario)
        {
            var grupo = await _grupoFuncionarioRepositorio.ObterPorId(grupoFuncionario);

            ICollection<Claim> claims = new List<Claim>();
            foreach (var item in grupo.Acesso)
            {
                Claim claim = new Claim(item.ClaimType, item.ClaimValue);
                claims.Add(claim);
            }
            var result = await _userManager.AddClaimsAsync(user, claims);

            if (result.Succeeded)
            {
                return true;
            }
            foreach (var error in result.Errors)
            {
                AddErro(error.Description);
            }
            return false;
        }

        private async Task<bool> UpdateClaimsFunciorio(string email, Guid grupoFuncionario)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.RemoveClaimsAsync(user, await _userManager.GetClaimsAsync(user));

            if (result.Succeeded)
            {
                await CriarClaimsFunciorio(user, grupoFuncionario);
                return true;
            }
            foreach (var error in result.Errors)
            {
                AddErro(error.Description);
            }
            return false;
        }
    }
}
