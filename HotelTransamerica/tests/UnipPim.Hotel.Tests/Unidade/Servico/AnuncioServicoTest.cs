using Moq;
using System.Linq;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Servicos;
using Xunit;

namespace UnipPim.Hotel.Tests.Unidade.Servico
{
    [Collection(nameof(HotelCollection))]
    public class AnuncioServicoTest
    {
        private readonly HotelTestFixture _hotelTestFixture;
        private AnuncioServico _anuncioServico;

        public AnuncioServicoTest(HotelTestFixture hotelTestFixture)
        {
            _hotelTestFixture = hotelTestFixture;
            _anuncioServico = _hotelTestFixture.ObterAnuncioServico();
        }

        [Fact(DisplayName = "Cadastrando um anuncio")]
        [Trait("Servico", "Anuncio")]
        public async Task Anuncio_Inserir_CadastroComSucesso()
        {
            //Arrange
            var anuncio = _hotelTestFixture.GerarAnuncio(1).FirstOrDefault();
            var fotos = _hotelTestFixture.GerarFotos(5);
            foreach (var item in fotos)
                anuncio.AddFoto(item);

            //Act
            await _anuncioServico.Insert(anuncio);

            //Assert
            _hotelTestFixture.AutoMocker.GetMock<IAnuncioRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Atualizando um anuncio")]
        [Trait("Servico", "Anuncio")]
        public async Task Anuncio_Update_AtualizandoComSucesso()
        {
            //Arrange
            var anuncio = _hotelTestFixture.GerarAnuncio(1).FirstOrDefault();            
            foreach (var item in _hotelTestFixture.GerarFotos(2))
                anuncio.AddFoto(item);

            var anuncioRetor = _hotelTestFixture.GerarAnuncio(1).FirstOrDefault();
            foreach (var item in _hotelTestFixture.GerarFotos(2))
                anuncioRetor.AddFoto(item);
            _hotelTestFixture.AutoMocker.GetMock<IAnuncioRepositorio>().Setup(x => x.ObterPorId(anuncio.Id).Result).Returns(anuncioRetor);
            
            //Act
            await _anuncioServico.Update(anuncio);

            //Assert
            _hotelTestFixture.AutoMocker.GetMock<IAnuncioRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
