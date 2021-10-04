using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace UnipPim.Hotel.Desktop.Service.Servicos.Handlers
{
    public class HttpClientAuthorizationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}
