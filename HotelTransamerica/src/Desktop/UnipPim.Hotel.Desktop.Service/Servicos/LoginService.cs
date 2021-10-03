using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UnipPim.Hotel.Desktop.Service.Extension;
using UnipPim.Hotel.Desktop.Service.Interfaces;
using UnipPim.Hotel.Desktop.Service.ModelsDTO;

namespace UnipPim.Hotel.Desktop.Service.Servicos
{
    public class LoginService : ServiceBase, ILoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AuthenticationUrl);
            _httpClient = httpClient;
        }

        public async Task<UserResponseLogin> Login(LoginRequest login)
        {
            var response = await _httpClient.PostAsync("/Api/V1/Autenticacao/PrimeiroAcesso", ObterContext(login));

            return await ReturnResponse<UserResponseLogin>(response);            
        }
    }
}
