using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Extensions.Midleware;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Authorize]
    [ClaimsAuthorize("Anuncio", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class AnuncioController : MainController
    {
        protected AnuncioController(IMapper mapper, 
                                    IUser user, 
                                    INotificacao notificacao) 
                                    : base(mapper, user, notificacao)
        {

        }

        [HttpGet("lista-anuncio")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
