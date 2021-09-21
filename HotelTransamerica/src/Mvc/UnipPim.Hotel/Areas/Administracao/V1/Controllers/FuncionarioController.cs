using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Area("Administracao")]
    public class FuncionarioController : MainController
    {
        public FuncionarioController(IMapper mapper,
                                        IUser user,
                                        INotificacao notificacao) :
                                        base(mapper, user, notificacao)
        {
            
        }
    }
}
