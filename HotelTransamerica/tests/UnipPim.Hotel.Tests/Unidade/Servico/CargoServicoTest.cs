using Moq;
using System.Linq;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Servicos;
using Xunit;

namespace UnipPim.Hotel.Tests.Unidade.Servico
{
    [Collection(nameof(HotelCollection))]
    public class CargoServicoTest
    {
        private readonly HotelTestFixture _hotelTestFixture;
        private CargoServico _cargoServico;

        public CargoServicoTest(HotelTestFixture hotelTestFixture)
        {
            _hotelTestFixture = hotelTestFixture;
            _cargoServico = _hotelTestFixture.ObterCargoServico();
        }
                
        [Fact(DisplayName = "Cadastrado um Cargo")]
        [Trait("Servico", "Cargo")]
        public async Task Cargo_Inserir_CadastroComSucesso()
        {
            //Arrange
            var cargo = _hotelTestFixture.GerarCargos(1).FirstOrDefault();
            
            //Act
            await _cargoServico.Insert(cargo);

            //Assert
            _hotelTestFixture.AutoMocker.GetMock<ICargoRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Atualizando um Cargo")]
        [Trait("Servico", "Cargo")]
        public async Task Cargo_Update_EditarComSucesso()
        {
            //Arrange
            var cargo = _hotelTestFixture.GerarCargos(1).FirstOrDefault();
            
            //Act
            await _cargoServico.Update(cargo);

            //Assert
            _hotelTestFixture.AutoMocker.GetMock<ICargoRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Deletando um Cargo")]
        [Trait("Servico", "Cargo")]
        public async Task Cargo_Delete_ExcluirComSucesso()
        {
            //Arrange
            var cargo = _hotelTestFixture.GerarCargos(1).FirstOrDefault();            
            _hotelTestFixture.AutoMocker.GetMock<ICargoRepositorio>().Setup(x => x.ObterPorId(cargo.Id).Result).Returns(cargo);
            
            //Act
            await _cargoServico.DeletarCargo(cargo.Id);

            //Assert
            _hotelTestFixture.AutoMocker.GetMock<ICargoRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
