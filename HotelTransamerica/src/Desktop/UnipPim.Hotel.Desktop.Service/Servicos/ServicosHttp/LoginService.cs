using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnipPim.Hotel.Desktop.Service.Interfaces;
using UnipPim.Hotel.Desktop.Service.ModelsDTO;
using UnipPim.Hotel.Desktop.Service.Servicos;

namespace UnipPim.Hotel.Desktop.Service.ServicosHttp.Servicos
{
    public class LoginService : ServiceBase, ILoginService
    {
        private readonly IUser _user;
        public LoginService(IUser user)
        {
            _user = user;
        }

        public async Task<ResponseResult> Login(LoginRequest login)
        {
            cookies = new CookieContainer();
            handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            var uri = new Uri($"{UriBase}Api/V1/Autenticacao/PrimeiroAcesso");
            
            using (var client = new HttpClient(handler))
            {
                var response = await client.PostAsync(uri, ObterContext(login));

                if (TratarErrosResponse(response))
                {
                    _user.AddCookie(cookies.GetCookies(uri).Cast<Cookie>());
                    _user.AddEmail(login.Email);
                    return ReturnOk();
                }
                
                return await DeserializeResponse<ResponseResult>(response);
            }
        }     
    }
}
