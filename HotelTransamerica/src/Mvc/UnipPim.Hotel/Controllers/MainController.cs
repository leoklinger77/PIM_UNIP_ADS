using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        }

        protected void ErrosTempData()
        {
            TempData["Erro"] = _notificacao.Erros().ToArray();
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
    }
}
