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
            services.AddScoped<IEstadoRepositorio, EstadoRepositorio>();
            services.AddScoped<IHospedeRepositorio, HospedeRepositorio>();
            services.AddScoped<IGrupoFuncionarioRepositorio, GrupoFuncionarioRepositorio>();

            //Servicos
            services.AddScoped<IEmailSender, EnviarEmail>();
            services.AddScoped<IFuncionarioServico, FuncionarioServico>();
            services.AddScoped<ICargoServico, CargoServico>();            
            services.AddScoped<IEstadoServico, EstadoServico>();
            services.AddScoped<IHospedeServico, HospedeServico>();
            services.AddScoped<IGrupoFuncionarioServico, GrupoFuncionarioServico>();

            //Notificacao
            services.AddScoped<INotificacao, Noficacao>();
        }
    }
}
