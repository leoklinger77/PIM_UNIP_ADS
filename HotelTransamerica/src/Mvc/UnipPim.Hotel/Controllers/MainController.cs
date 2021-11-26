using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Controllers
{
    public abstract class MainController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly IUser _user;
        private readonly INotificacao _notificacao;

        protected MainController(IMapper mapper, IUser user, INotificacao notificacao)
        {
            _mapper = mapper;
            _user = user;
            _notificacao = notificacao;
        }

        protected void AddErro(string erro)
        {
            _notificacao.AddError(erro);
            OperacaoValida();
        }

        protected void ErrosTempData()
        {
            string texto = string.Empty;
            foreach (var item in _notificacao.Erros())
            {
                texto = item + " <br/>";
            }
            TempData["Erro"] = texto;
        }

        protected bool OperacaoValida()
        {
            if (_notificacao.ContemErros())
            {
                foreach (var item in _notificacao.Erros())
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return true;
            }
            return false;
        }

        protected IActionResult CustomView(object obj = null)
        {
            OperacaoValida();
            return View(obj);
        }

        //Retorno Rota da API

        protected ActionResult CustomResponse(object result = null)
        {
            if (!OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messagens" , _notificacao.Erros().ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddErro(erros.ToString());
            }
            return CustomResponse();
        }             
    }
}
