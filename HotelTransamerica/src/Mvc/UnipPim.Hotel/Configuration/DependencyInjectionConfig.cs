using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Notificacoes;
using UnipPim.Hotel.Dominio.Servicos;
using UnipPim.Hotel.Extensions;
using UnipPim.Hotel.Infra.Repositorios;
using UnipPim.Hotel.Relatorio;
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
            services.AddScoped<IQuartoRepositorio, QuartoRepositorio>();
            services.AddScoped<IAnuncioRepositorio, AnuncioRepositorio>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();            
            services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
            services.AddScoped<ICaixaRepositorio, CaixaRepositorio>();

            //Servicos
            services.AddScoped<INotificacao, Noficacao>();
            services.AddScoped<IEmailSender, EnviarEmail>();            
            services.AddScoped<IFuncionarioServico, FuncionarioServico>();
            services.AddScoped<ICargoServico, CargoServico>();            
            services.AddScoped<IEstadoServico, EstadoServico>();
            services.AddScoped<IHospedeServico, HospedeServico>();
            services.AddScoped<IGrupoFuncionarioServico, GrupoFuncionarioServico>();
            services.AddScoped<IQuartoServico, QuartoServico>();
            services.AddScoped<IAnuncioServico, AnuncioServico>();
            services.AddScoped<ICategoriaServico, CategoriaServico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();            
            services.AddScoped<IReservaServico, ReservaServico>();
            services.AddScoped<ICaixaServico, CaixaServico>();

            //services.AddScoped<RelatorioFuncionario>();
        }
    }
}
