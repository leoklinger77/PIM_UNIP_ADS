using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Controllers
{
    public class HomeController : MainController
    {
        private readonly IAnuncioServico _anuncioServico;
        public HomeController(IMapper mapper,
                                IUser user,
                                INotificacao notificacao, IAnuncioServico anuncioServico)
                                : base(mapper, user, notificacao)
        {
            _anuncioServico = anuncioServico;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _anuncioServico.TresAnunciosAleatorios();

            return View(_mapper.Map<IEnumerable<AnuncioViewModel>>(result));
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if (id == 403 || id == 401)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso Negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
