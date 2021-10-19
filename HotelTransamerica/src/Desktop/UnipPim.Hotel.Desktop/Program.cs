using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using UnipPim.Hotel.Desktop.Service.Interfaces;
using UnipPim.Hotel.Desktop.Service.Servicos;
using UnipPim.Hotel.Desktop.Service.ServicosHttp.Servicos;

namespace UnipPim.Hotel.Desktop
{
    static class Program
    {       
        [STAThread]
        static void Main()
        {
            //Injection Dependency
            var serviceCollection = new ServiceCollection();
            ConfigService(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();


            //Run
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(serviceProvider));
        }

        public static void ConfigService(IServiceCollection services)
        {
            services.AddSingleton<IUser, User>();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<ICaixaService, CaixaService>();
        }
    }
}
