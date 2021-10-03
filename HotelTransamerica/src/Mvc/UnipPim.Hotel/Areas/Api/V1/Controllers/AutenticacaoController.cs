using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Areas.Api.V1.Controllers
{
    [Area("Api")]
    [Route("Api/V1/[controller]")]
    public class AutenticacaoController : MainController
    {
        public AutenticacaoController(IMapper mapper, 
                                        IUser user, 
                                        INotificacao notificacao) 
                                        : base(mapper, user, notificacao)
        {
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> PrimeiroAcesso(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse();
        }
    }
}
