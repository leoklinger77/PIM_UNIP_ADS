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

        private async Task<bool> ResponseIsNull(HttpResponseMessage responseMessage)
            => string.IsNullOrEmpty(await responseMessage.Content.ReadAsStringAsync());


        protected async Task<dynamic> ReturnResponse<T>(HttpResponseMessage response)
        {
            if (!TratarErrosResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeResponse<ResponseResult>(response)
                };
            }

            if (await ResponseIsNull(response)) return ReturnOk();

            return await DeserializeResponse<T>(response);
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
            return new ResponseResult();
        }
    }
}
