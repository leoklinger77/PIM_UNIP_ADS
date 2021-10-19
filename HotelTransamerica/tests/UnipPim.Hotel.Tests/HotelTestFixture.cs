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

        public void Dispose() { }
    }
}
