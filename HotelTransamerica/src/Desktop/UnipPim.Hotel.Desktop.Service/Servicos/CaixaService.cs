using System.Threading.Tasks;
using UnipPim.Hotel.Desktop.Service.Interfaces;

namespace UnipPim.Hotel.Desktop.Service.Servicos
{
    public class CaixaService : ICaixaService
    {
        private bool _caixaAberto;

        public CaixaService() 
        { 

        }

        public void AbrirCaixa()
        {
            _caixaAberto = true;
        }

        public async Task<bool> CaixaAberto()
        {
            return _caixaAberto;
        }
    }
}
