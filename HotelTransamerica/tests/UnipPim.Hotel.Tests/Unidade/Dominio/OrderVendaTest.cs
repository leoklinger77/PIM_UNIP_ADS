using Bogus;
using System;
using System.Linq;
using UnipPim.Hotel.Dominio.Models;
using Xunit;

namespace UnipPim.Hotel.Tests.Unidade.Dominio
{
    [Collection(nameof(HotelCollection))]
    public class OrderVendaTest
    {
        private readonly HotelTestFixture _hotelTestFixture;

        public OrderVendaTest(HotelTestFixture hotelTestFixture)
        {
            _hotelTestFixture = hotelTestFixture;
        }

        [Fact]
        [Trait("Dominio", "OrderVenda")]
        public void OrderVenda_AdicinandoItem_AdicionandoDoisItemComSucesso()
        {
            //Arrange
            var orderVenda = _hotelTestFixture.GerarOrderVendaComItensVenda(1, 0).FirstOrDefault();

            //Act            
            orderVenda.AddItem(_hotelTestFixture.GerarItensVenda(2, orderVenda.Id).FirstOrDefault());
            orderVenda.AddItem(_hotelTestFixture.GerarItensVenda(2, orderVenda.Id).FirstOrDefault());

            //Assert
            Assert.Equal(orderVenda.QuantidadeTotal, orderVenda.ItensVendas.Sum(x => x.Quantidade));
            Assert.Equal(orderVenda.ValorTotal, orderVenda.ItensVendas.Sum(x => x.PrecoVenda));
        }

        [Fact]
        [Trait("Dominio", "OrderVenda")]
        public void OrderVenda_AdicionandoMesmoProduto_NaoPodeRepetirOProdutoDeveSomarQuantidadeDoProduto()
        {
            //Arrange
            var orderVenda = _hotelTestFixture.GerarOrderVendaComItensVenda(1, 0).FirstOrDefault();

            var item = _hotelTestFixture.GerarItensVenda(2, orderVenda.Id).FirstOrDefault();
            var item2 = _hotelTestFixture.GerarItensVenda(2, orderVenda.Id).FirstOrDefault();
            //Act            
            orderVenda.AddItem(item);
            orderVenda.AddItem(item);
            orderVenda.AddItem(item);
            orderVenda.AddItem(item);

            orderVenda.AddItem(item2);

            //Assert
            Assert.Equal(item.Quantidade, orderVenda.ItensVendas.Where(x => x.ProdutoId == item.ProdutoId).FirstOrDefault().Quantidade);
            Assert.Equal(item.PrecoVenda, orderVenda.ItensVendas.Where(x => x.ProdutoId == item.ProdutoId).FirstOrDefault().PrecoVenda);
            Assert.Single(orderVenda.ItensVendas.Where(x => x.ProdutoId == item.ProdutoId));            
        }

        [Fact]
        [Trait("Dominio", "OrderVenda")]
        public void OrderVenda_AdicioandoERemovendoUmProduto_ValorFinalDeveSer0()
        {
            //Arrange
            var orderVenda = _hotelTestFixture.GerarOrderVendaComItensVenda(1, 0).FirstOrDefault();

            var item = _hotelTestFixture.GerarItensVenda(2, orderVenda.Id).FirstOrDefault();            
            //Act            
            orderVenda.AddItem(item);
            orderVenda.AddItem(item);
            orderVenda.AddItem(item);
            orderVenda.AddItem(item);

            orderVenda.RemoveItem(item);

            //Assert
            Assert.Empty(orderVenda.ItensVendas);            
        }
    }
}
