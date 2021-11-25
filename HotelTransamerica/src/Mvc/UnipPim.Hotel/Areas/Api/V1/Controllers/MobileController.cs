using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;

namespace UnipPim.Hotel.Areas.Api.V1.Controllers
{
    [Area("Api")]
    [Route("Api/V1/Mobille")]
    public class MobileController : ApiController
    {

        private readonly IReservaRepositorio _reservaRepositorio;
        private readonly IQuartoRepositorio _quartoRepositorio;
        private readonly IAnuncioRepositorio _anuncioRepositorio;

        public MobileController(IMapper mapper, IUser user, INotificacao notificacao, IReservaRepositorio reservaRepositorio, IQuartoRepositorio quartoRepositorio, IAnuncioRepositorio anuncioRepositorio) : base(mapper, user, notificacao)
        {
            _reservaRepositorio = reservaRepositorio;
            _quartoRepositorio = quartoRepositorio;
            _anuncioRepositorio = anuncioRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            

            return Ok();
        }
    }
}
