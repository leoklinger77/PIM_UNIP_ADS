using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Notificacoes;
using UnipPim.Hotel.Dominio.Servicos;
using UnipPim.Hotel.Extensions;
using UnipPim.Hotel.Infra.Repositorios;
using UnipPim.Hotel.Servicos;

namespace UnipPim.Hotel.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services)
        {
            //Identity
            services.AddScoped<IUser, User>();

            //Repositorio
            services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddScoped<ICargoRepositorio, CargoRepositorio>();

            //Servicos
            services.AddScoped<IFuncionarioServico, FuncionarioServico>();
            services.AddScoped<ICargoServico, CargoServico>();
            services.AddScoped<IEmailSender, EnviarEmail>();

            //Notificacao
            services.AddScoped<INotificacao, Noficacao>();
        }
    }
}
