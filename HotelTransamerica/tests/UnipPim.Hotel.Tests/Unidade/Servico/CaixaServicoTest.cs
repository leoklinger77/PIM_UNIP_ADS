using Moq;
using System;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Servicos;
using Xunit;

namespace UnipPim.Hotel.Tests.Unidade.Servico
{
    [Collection(nameof(HotelCollection))]
    public class CaixaServicoTest
    {
        private readonly HotelTestFixture _hotelTestFixture;
        private CaixaServico _caixaServico;

        public CaixaServicoTest(HotelTestFixture hotelTestFixture)
        {
            _hotelTestFixture = hotelTestFixture;
            _caixaServico = _hotelTestFixture.ObterCaixaServico();
        }

        [Theory(DisplayName = "Adicionar Item Pedido Vazio")]
        [InlineData(0)]        
        [InlineData(10.10)]        
        [Trait("Servico", "Caixa")]
        public async Task Caixa_AbrirCaixa_DeveAbrirOCaixaESalvarNoDB(decimal valor)
        {
            //Arrange & Act                    
            await _caixaServico.AbrirCaixa(Guid.NewGuid(), valor);

            //Assert
            _hotelTestFixture.AutoMocker.GetMock<ICaixaRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
