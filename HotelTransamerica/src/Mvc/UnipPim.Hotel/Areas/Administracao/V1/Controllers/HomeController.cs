using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class HomeController : MainController
    {
        public HomeController(IMapper mapper, IUser user, INotificacao notificacao) 
                                : base(mapper, user, notificacao)
        {

        }

        [HttpGet("pagina-inicial")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
