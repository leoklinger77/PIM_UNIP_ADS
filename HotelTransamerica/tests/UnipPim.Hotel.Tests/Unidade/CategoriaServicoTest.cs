using Moq;
using System.Linq;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Servicos;
using Xunit;

namespace UnipPim.Hotel.Tests.Unidade
{
    [Collection(nameof(HotelCollection))]
    public class CategoriaServicoTest
    {
        private readonly HotelTestFixture _hotelTestFixture;
        private CategoriaServico _categoriaServico;

        public CategoriaServicoTest(HotelTestFixture hotelTestFixture)
        {
            _hotelTestFixture = hotelTestFixture;
            _categoriaServico = _hotelTestFixture.ObterCategoriaServico();
        }
                
        [Fact(DisplayName = "Cadastrando uma Categoria")]
        [Trait("Servico", "Categoria")]
        public async Task Categoria_Inserir_CadastroComSucesso()
        {
            //Arrange
            var categoria = _hotelTestFixture.GerarCategorias(1).FirstOrDefault();           
            //Act
            await _categoriaServico.Insert(categoria);
            //Assert
            _hotelTestFixture.AutoMocker.GetMock<ICategoriaRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Atualizando uma Categoria")]
        [Trait("Servico", "Categoria")]
        public async Task Categoria_Update_EditarComSucesso()
        {
            //Arrange
            var categoria = _hotelTestFixture.GerarCategorias(1).FirstOrDefault();
            //Act
            await _categoriaServico.Update(categoria);
            //Assert
            _hotelTestFixture.AutoMocker.GetMock<ICategoriaRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Deletando uma Categoria")]
        [Trait("Servico", "Categoria")]
        public async Task Categoria_Delete_ExcluirComSucesso()
        {
            //Arrange
            var categoria = _hotelTestFixture.GerarCategorias(1).FirstOrDefault();
            _hotelTestFixture.AutoMocker.GetMock<ICategoriaRepositorio>().Setup(x => x.ObterPorId(categoria.Id).Result).Returns(categoria);
            //Act
            await _categoriaServico.Delete(categoria.Id);
            //Assert
            _hotelTestFixture.AutoMocker.GetMock<ICategoriaRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
