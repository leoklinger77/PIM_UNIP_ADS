using Bogus;
using Bogus.Extensions.Brazil;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Servicos;
using Xunit;

namespace UnipPim.Hotel.Tests
{
    [CollectionDefinition(nameof(HotelCollection))]
    public class HotelCollection : ICollectionFixture<HotelTestFixture> { }
    public class HotelTestFixture : IDisposable
    {
        public AutoMocker AutoMocker;

        public ProdutoServico ProdutoServico;
        public CategoriaServico CategoriaServico;
        public CargoServico CargoServico;
        public FuncionarioServico FuncionarioServico;
        public AnuncioServico AnuncioServico;
        public CaixaServico CaixaServico;

        //Servicos
        public ProdutoServico ObterProdutoServico()
        {
            AutoMocker = new AutoMocker();
            ProdutoServico = AutoMocker.CreateInstance<ProdutoServico>();
            return ProdutoServico;
        }
        public CategoriaServico ObterCategoriaServico()
        {
            AutoMocker = new AutoMocker();
            CategoriaServico = AutoMocker.CreateInstance<CategoriaServico>();
            return CategoriaServico;
        }
        public CargoServico ObterCargoServico()
        {
            AutoMocker = new AutoMocker();
            CargoServico = AutoMocker.CreateInstance<CargoServico>();
            return CargoServico;
        }
        public FuncionarioServico ObterFuncionarioServico()
        {
            AutoMocker = new AutoMocker();
            FuncionarioServico = AutoMocker.CreateInstance<FuncionarioServico>();
            return FuncionarioServico;
        }
        public AnuncioServico ObterAnuncioServico()
        {
            AutoMocker = new AutoMocker();
            AnuncioServico = AutoMocker.CreateInstance<AnuncioServico>();
            return AnuncioServico;
        }
        public CaixaServico ObterCaixaServico()
        {
            AutoMocker = new AutoMocker();
            CaixaServico = AutoMocker.CreateInstance<CaixaServico>();
            return CaixaServico;
        }



        //Dominio
        public IEnumerable<Categoria> GerarCategorias(int quantidade)
        {
            return new Faker<Categoria>(locale: "pt_BR")
               .CustomInstantiator(f => new Categoria(f.Commerce.Categories(5).ToString())).Generate(quantidade);
        }
        public IEnumerable<Cargo> GerarCargos(int quantidade)
        {
            return new Faker<Cargo>(locale: "pt_BR")
               .CustomInstantiator(f => new Cargo(f.Name.JobDescriptor().ToString())).Generate(quantidade);
        }
        public IEnumerable<Produto> GerarProdutos(int quantidade)
        {
            return new Faker<Produto>(locale: "pt_BR")
               .CustomInstantiator(f => new Produto(f.Commerce.ProductName(), f.Commerce.Ean13(), f.Random.Number(0, 500), decimal.Parse(f.Commerce.Price(0, 1000)), Guid.NewGuid())).Generate(quantidade);
        }
        public IEnumerable<Funcionario> GerarFuncionarios(int quantidade)
        {
            return new Faker<Funcionario>(locale: "pt_BR")
               .CustomInstantiator(f =>
                                    new Funcionario(f.Name.FullName(), f.Person.Cpf(), f.Date.Past(16), Guid.NewGuid(), Guid.NewGuid())
                                   ).Generate(quantidade);
        }
        public IEnumerable<Anuncio> GerarAnuncio(int quantidade)
        {
            return new Faker<Anuncio>(locale: "pt_BR")
               .CustomInstantiator(f =>
                                    new Anuncio(f.Name.JobTitle(), true, f.Random.Number(0, 500), decimal.Parse(f.Commerce.Price()), Guid.NewGuid(), Guid.NewGuid())
                                   ).Generate(quantidade);
        }
        public IEnumerable<Foto> GerarFotos(int quantidade)
        {
            return new Faker<Foto>(locale: "pt_BR")
               .CustomInstantiator(f =>
                                    new Foto(f.Image.DataUri(40, 40))
                                   ).Generate(quantidade);
        }
        public IEnumerable<OrderVenda> GerarOrderVendaComItensVenda(int qtdeOrder, int qtdeItensVenda)
        {
            var orderVenda = new Faker<OrderVenda>(locale: "pt_BR")
               .CustomInstantiator(f =>
                                    new OrderVenda(Guid.NewGuid(),f.Person.Cpf())
                                   ).Generate(qtdeOrder);

            foreach (var item in orderVenda)
            {
                for (int i = 0; i < qtdeItensVenda; i++)
                {
                    item.AddItem(new Faker<ItensVenda>(locale: "pt_BR")
                                    .CustomInstantiator(f =>
                                                        new ItensVenda(item.Id, Guid.NewGuid(), decimal.Parse(f.Commerce.Price(0, 5000, 2)), f.Random.Int(0, 10))
                                                        ));
                }

            }

            return orderVenda;

        }

        public IEnumerable<ItensVenda> GerarItensVenda(int quantidade, Guid orderVendaId)
        {
            return new Faker<ItensVenda>(locale: "pt_BR")
                                    .CustomInstantiator(f =>
                                                        new ItensVenda(orderVendaId, Guid.NewGuid(), decimal.Parse(f.Commerce.Price(0, 5000, 2)), f.Random.Int(1, 10))
                                                        ).Generate(quantidade);
        }

        public void Dispose() { }
    }
}
