using Moq;
using System.Linq;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Servicos;
using Xunit;

namespace UnipPim.Hotel.Tests.Unidade.Servico
{
    [Collection(nameof(HotelCollection))]
    public class ProdutoServicoTest
    {
        private readonly HotelTestFixture _hotelTestFixture;
        private ProdutoServico _produtoServico;

        public ProdutoServicoTest(HotelTestFixture hotelTestFixture)
        {
            _hotelTestFixture = hotelTestFixture;
            _produtoServico = _hotelTestFixture.ObterProdutoServico();
        }
                
        [Fact(DisplayName = "Cadastrado um Produto")]
        [Trait("Servico", "Produto")]
        public async Task Produto_Inserir_CadastroComSucesso()
        {
            //Arrange
            var produto = _hotelTestFixture.GerarProdutos(1).FirstOrDefault();            
            //Act
            await _produtoServico.Insert(produto);

            //Assert
            _hotelTestFixture.AutoMocker.GetMock<IProdutoRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Atualizando um Produto")]
        [Trait("Servico", "Produto")]
        public async Task Produto_Update_EditarComSucesso()
        {
            //Arrange
            var produto = _hotelTestFixture.GerarProdutos(1).FirstOrDefault();
            //Act
            await _produtoServico.Update(produto);

            //Assert
            _hotelTestFixture.AutoMocker.GetMock<IProdutoRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Deletando um Produto")]
        [Trait("Servico", "Produto")]
        public async Task Produto_Delete_ExcluirComSucesso()
        {
            //Arrange
            var produto = _hotelTestFixture.GerarProdutos(1).FirstOrDefault();            
            _hotelTestFixture.AutoMocker.GetMock<IProdutoRepositorio>().Setup(x => x.ObterPorId(produto.Id).Result).Returns(produto);

            //Act
            await _produtoServico.Delete(produto.Id);

            //Assert
            _hotelTestFixture.AutoMocker.GetMock<IProdutoRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
