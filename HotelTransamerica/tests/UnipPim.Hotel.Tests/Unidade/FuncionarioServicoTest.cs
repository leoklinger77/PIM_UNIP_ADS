using Moq;
using System.Linq;
using System.Threading.Tasks;
using UnipPim.Hotel.Dominio.Interfaces.Repositorio;
using UnipPim.Hotel.Dominio.Servicos;
using Xunit;

namespace UnipPim.Hotel.Tests.Unidade
{
    [Collection(nameof(HotelCollection))]
    public class FuncionarioServicoTest
    {
        private readonly HotelTestFixture _hotelTestFixture;
        public FuncionarioServico _funcionarioServico;

        public FuncionarioServicoTest(HotelTestFixture hotelTestFixture)
        {
            _hotelTestFixture = hotelTestFixture;
            _funcionarioServico = _hotelTestFixture.ObterFuncionarioServico();
        }

        [Fact(DisplayName = "Cadastrando um funcionario")]
        [Trait("Servico", "Funcionario")]
        public async Task Funcionario_Inserir_CadastroComSucesso()
        {
            //Arrange
            var funcionario = _hotelTestFixture.GerarFuncionarios(1).FirstOrDefault();
            
            //Act
            await _funcionarioServico.Insert(funcionario);
            
            //Assert
            _hotelTestFixture.AutoMocker.GetMock<IFuncionarioRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Cadastrando um funcionario")]
        [Trait("Servico", "Funcionario")]
        public async Task Funcionario_Update_CadastroComSucesso()
        {
            //Arrange
            var funcionario = _hotelTestFixture.GerarFuncionarios(1).FirstOrDefault();
            
            //Act
            await _funcionarioServico.Update(funcionario);
            
            //Assert
            _hotelTestFixture.AutoMocker.GetMock<IFuncionarioRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "Deletando um funcionario")]
        [Trait("Servico", "Funcionario")]
        public async Task Categoria_Delete_ExcluirComSucesso()
        {
            //Arrange
            var funcionario = _hotelTestFixture.GerarFuncionarios(1).FirstOrDefault();
            _hotelTestFixture.AutoMocker.GetMock<IFuncionarioRepositorio>().Setup(x => x.ObterPorId(funcionario.Id).Result).Returns(funcionario);
            
            //Act
            await _funcionarioServico.DeletarFuncionario(funcionario.Id);
            
            //Assert
            _hotelTestFixture.AutoMocker.GetMock<IFuncionarioRepositorio>().Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
