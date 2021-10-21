using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Areas.Api.V1.Controllers
{
    [Area("Api")]    
    [Route("Api/V1/[controller]")]
    public class AutenticacaoController : ApiController
    {
        private readonly SignInManager<IdentityUser> _signInManager;        
        public AutenticacaoController(IMapper mapper,
                                        IUser user,
                                        INotificacao notificacao,
                                        SignInManager<IdentityUser> signInManager)
                                        : base(mapper, user, notificacao)
        {
            _signInManager = signInManager;            
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> PrimeiroAcesso(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, true);

            if (result.RequiresTwoFactor)
            {
                AddErro("2FA Requerido.");
            }
            else if (result.Succeeded)
            {
                return CustomResponse();
            }
            else if (result.IsLockedOut)
            {
                AddErro("Usuario bloqueado por tentativas inválidas.");
            }
            else
            {
                AddErro("Usuario ou senha inválidos.");
            }
            return CustomResponse();
        }
    }
}
