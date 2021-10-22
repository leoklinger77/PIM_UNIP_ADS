using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnipPim.Hotel.Desktop.Service.Interfaces;
using UnipPim.Hotel.Desktop.Service.ModelsDTO;

namespace UnipPim.Hotel.Desktop.Service.Servicos
{
    public class CaixaService : ServiceBase, ICaixaService
    {
        private readonly IUser _user;
        public CaixaService(IUser user)
        {
            _user = user;
        }

        public async Task<ResponseResult> AbrirCaixa(decimal value)
        {
            cookies = new CookieContainer();
            foreach (var item in _user.GetCookie())
                cookies.Add(item);
            handler = new HttpClientHandler();
            handler.CookieContainer = cookies;           

            using (var client = new HttpClient(handler))
            {
                var response = await client.GetAsync(new Uri($"{UriBase}Api/V1/Caixa/Abrircaixa/{value}"));

                if (TratarErrosResponse(response))
                {
                    return ReturnOk();
                }

                return await DeserializeResponse<ResponseResult>(response);
            }
        }

        public async Task<ResponseResult<ProdutoDTO>> BuscarProdutoPorCodigoDeBarras(string codigo)
        {
            cookies = new CookieContainer();
            foreach (var item in _user.GetCookie())
                cookies.Add(item);
            handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            using (var client = new HttpClient(handler))
            {
                var response = await client.GetAsync(new Uri($"{UriBase}Api/V1/Caixa/produto/{codigo}"));

                if (TratarErrosResponse(response))
                {
                    return new ResponseResult<ProdutoDTO>() { Class = await DeserializeResponse<ProdutoDTO>(response) };
                }

                return new ResponseResult<ProdutoDTO>() { Response = await DeserializeResponse<ResponseResult>(response) };
            }
        }

        public async Task<ResponseResult> FecharCaixa()
        {
            cookies = new CookieContainer();
            foreach (var item in _user.GetCookie())
                cookies.Add(item);
            handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            using (var client = new HttpClient(handler))
            {
                var response = await client.GetAsync(new Uri($"{UriBase}Api/V1/Caixa/FecharCaixa"));

                if (TratarErrosResponse(response))
                {
                    return ReturnOk();
                }

                return await DeserializeResponse<ResponseResult>(response);
            }
        }

        public async Task<ResponseResult<CaixaDTO>> ObterCaixa()
        {
            cookies = new CookieContainer();
            foreach (var item in _user.GetCookie())
                cookies.Add(item);

            handler = new HttpClientHandler();
            handler.CookieContainer = cookies;            

            using (var client = new HttpClient(handler))
            {
                var response = await client.GetAsync(new Uri($"{UriBase}Api/V1/Caixa/obterCaixa"));

                if (TratarErrosResponse(response))
                {
                    return new ResponseResult<CaixaDTO> { Class = await DeserializeResponse<CaixaDTO>(response) };
                }

                return new ResponseResult<CaixaDTO> { Response = await DeserializeResponse<ResponseResult>(response) };
            }
        }
    }
}
