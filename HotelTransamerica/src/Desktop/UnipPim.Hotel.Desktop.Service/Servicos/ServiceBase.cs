using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UnipPim.Hotel.Desktop.Extension.Servicos;
using UnipPim.Hotel.Desktop.Service.ModelsDTO;

namespace UnipPim.Hotel.Desktop.Service.Servicos
{
    public class ServiceBase
    {
        protected CookieContainer cookies;
        protected string UriBase = "https://localhost:44342/";
        protected HttpClientHandler handler;

        public ServiceBase(){}

        protected StringContent ObterContext(object data)
        {
            var result = JsonSerializer.Serialize(data);
            return new StringContent(result, Encoding.UTF8, "application/json");
        }

        protected async Task<T> DeserializeResponse<T>(HttpResponseMessage responseMessage)
        {

            var result = await responseMessage.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }           

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        protected ResponseResult ReturnOk()
        {
            return new ResponseResult() { Title = "Sucesso", Status = 200};
        }
    }
}
