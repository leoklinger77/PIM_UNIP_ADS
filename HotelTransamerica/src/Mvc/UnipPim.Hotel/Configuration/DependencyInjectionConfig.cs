using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Notificacoes;
using UnipPim.Hotel.Dominio.Servicos;
using UnipPim.Hotel.Extensions;
using UnipPim.Hotel.Infra.Repositorios;

namespace UnipPim.Hotel.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //Identity
            services.AddScoped<IUser, User>();

            //Repositorio
            services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
            services.AddScoped<ICargoRepositorio, CargoRepositorio>();

            //Servicos
            services.AddScoped<IFuncionarioServico, FuncionarioServico>();
            services.AddScoped<ICargoServico, CargoServico>();

            //Notificacao
            services.AddScoped<INotificacao, Noficacao>();
        }
    }
}
