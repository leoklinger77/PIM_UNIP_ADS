using System.Threading.Tasks;

namespace UnipPim.Hotel.Desktop.Service.Interfaces
{
    public interface ICaixaService
    {
        void AbrirCaixa();
        Task<bool> CaixaAberto();
    }
}
