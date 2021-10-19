using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;

namespace UnipPim.Hotel.Controllers
{
    [Authorize]
    public class CheckoutReservaController : MainController
    {
        private readonly IAnuncioServico _anuncioServico;

        public CheckoutReservaController(IMapper mapper, IUser user, INotificacao notificacao, IAnuncioServico anuncioServico) : base(mapper, user, notificacao)
        {
            _anuncioServico = anuncioServico;
        }

        [HttpGet]
        public async Task<IActionResult> IniciarReserva(Guid anuncioId)
        {
            var anuncioDb = await _anuncioServico.ObterPorId(anuncioId);

            if (anuncioId == null) return BadRequest();

            //criarCriar a Reserva

            return View();
        }
    }
}
