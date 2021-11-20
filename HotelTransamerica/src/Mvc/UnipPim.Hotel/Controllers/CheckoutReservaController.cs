using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Controllers
{
    [Authorize]
    public class CheckoutReservaController : MainController
    {
        private readonly IAnuncioServico _anuncioServico;
        private readonly IHospedeServico _hospedeServico;
        private readonly IFuncionarioServico _funcionarioServico;
        private readonly IReservaServico _reservaServico;

        public CheckoutReservaController(IMapper mapper, 
                                            IUser user, 
                                            INotificacao notificacao, 
                                            IAnuncioServico anuncioServico, 
                                            IHospedeServico hospedeServico, 
                                            IFuncionarioServico funcionarioServico, 
                                            IReservaServico reservaServico) 
                                            : base(mapper, user, notificacao)
        {
            _anuncioServico = anuncioServico;
            _hospedeServico = hospedeServico;
            _funcionarioServico = funcionarioServico;
            _reservaServico = reservaServico;
        }

        [HttpGet]
        public async Task<IActionResult> IniciarReserva(Guid anuncioId)
        {
            var anuncioDb = await _anuncioServico.ObterPorId(anuncioId);

            if (anuncioId == null) return BadRequest();

            //criarCriar a Reserva
            var hospede = await _hospedeServico.ObterPorId(_user.UserId);

            if (hospede == null)
            {
                var func = await _funcionarioServico.ObterPorId(_user.UserId);
                hospede = new Hospede(func.Id, func.NomeCompleto, func.Cpf, func.Nascimento);
                await _hospedeServico.Insert(hospede);
            }

            var init = new FechamentoReservaViewModel()
            {
                Anuncio = _mapper.Map<AnuncioViewModel>(anuncioDb),
                Hospede = _mapper.Map<HospedeViewModel>(hospede),                
                Entrada = DateTime.Now,
                Saida = DateTime.Now.AddDays(7)
                
            };

            return View(init);
        }

        [HttpPost]
        public async Task<IActionResult> IniciarReserva(FechamentoReservaViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            if (!EfetuarPagamentoMock())
            {
                AddErro("Pagamento recusado pela Operadora do Cartão. Verifique os dados fornecidos e tente novamente.");
                return View(viewModel);
            }

            var reserva = new Reserva(viewModel.Anuncio.Id, _user.UserId, viewModel.Entrada, viewModel.Saida, viewModel.Anuncio.Custo);

            await _reservaServico.Insert(reserva);

            if (OperacaoValida())
            {
                return View(viewModel);
            }

            return View("Confirmacao");
        }

        private bool EfetuarPagamentoMock()
        {
            return new Random().Next(2) == 0;
        }
    }
}
