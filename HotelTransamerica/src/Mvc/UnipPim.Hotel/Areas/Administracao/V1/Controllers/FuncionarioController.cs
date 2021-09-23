using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Dominio.Tools;
using UnipPim.Hotel.Extensions.Midleware;
using UnipPim.Hotel.Models;
using X.PagedList;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Authorize]
    [ClaimsAuthorize("Funcionario", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class FuncionarioController : MainController
    {
        private readonly IFuncionarioServico _funcionarioServico;
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
                                IEstadoServico estadoServico) :
                                base(mapper, user, notificacao)
        {
            _funcionarioServico = funcionarioServico;
            _userManager = userManager;
            _cargoServico = cargoServico;
            _emailSender = emailSender;
            _estadoServico = estadoServico;
        }

        [HttpGet("lista-Funcionario")]
        public async Task<IActionResult> Index(int page = 1, int size = 8, string query = null)
        {            
            return View(_mapper.Map<PaginacaoViewModel<FuncionarioViewModel>>(await _funcionarioServico.PaginacaoListaFuncionario(page, size, query)));
        }

        [HttpGet("novo-Funcionario")]
        public async Task<IActionResult> NovoFuncionario()
        {
            return View(await PopulaListaCargo(new FuncionarioViewModel()));
        }

        [HttpPost("novo-Funcionario")]
        public async Task<IActionResult> NovoFuncionario(FuncionarioViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(await PopulaListaCargo(viewModel));

            var newFuncionario = await CriarFuncionario(viewModel);
            await _funcionarioServico.Insert(newFuncionario);

            if (OperacaoValida()) return View(await PopulaListaCargo(viewModel));

            if (!await CriarLoginFuncionario(viewModel.Email))
            {
                await _funcionarioServico.DeletarFuncionario(newFuncionario);
                return View(await PopulaListaCargo(viewModel));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar-Funcionario")]
        public async Task<IActionResult> EditarFuncionario(Guid id)
        {
            var resultado = await ObterFuncionarioPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(await PopulaListaCargo(await PopulaFuncionario(resultado)));
        }

        [HttpPost("editar-Funcionario")]
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

            if (OperacaoValida()) return View(await PopulaListaCargo(viewModel));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes-Funcionario")]
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
        public async Task<IActionResult> DeletarFuncionario(Guid id)
        {
            var resultado = await ObterFuncionarioPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }
            return View(await PopulaListaCargo(await PopulaFuncionario(resultado)));
        }

        [HttpPost("deletar-Funcionario")]
        public async Task<IActionResult> ConfirmaDeletarFuncionario(Guid id)
        {
            var resultado = await ObterFuncionarioPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            await _funcionarioServico.DeletarFuncionario(resultado);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            await DeletarLoginFuncionario(resultado.Emails.First().EnderecoEmail);

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
            var newfuncionario = new Funcionario(viewModel.NomeCompleto, viewModel.Cpf, viewModel.Nascimento, viewModel.CargoId);

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

        private async Task<bool> CriarLoginFuncionario(string email)
        {
            var user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = false };
            var password = CodeGeneretor.GerarSenha(10);
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {

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

        private async Task<bool> DeletarLoginFuncionario(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                AddErro("User Login não encontrado.");
                return false;
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

        private async Task<FuncionarioViewModel> PopulaListaCargo(FuncionarioViewModel viewModel)
        {
            viewModel.ListaCargo = _mapper.Map<IEnumerable<CargoViewModel>>(await _cargoServico.ObterTodos());
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
    }
}
