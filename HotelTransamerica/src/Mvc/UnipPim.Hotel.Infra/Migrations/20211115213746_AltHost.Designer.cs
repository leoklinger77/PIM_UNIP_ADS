// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnipPim.Hotel.Infra.Data;

namespace UnipPim.Hotel.Infra.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20211115213746_AltHost")]
    partial class AltHost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Acesso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("GrupoFuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GrupoFuncionarioId");

                    b.ToTable("TB_Acesso");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Anuncio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<Guid>("QuartoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("QuartoId");

                    b.ToTable("TB_Anuncio");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Caixa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Abertura")
                        .HasColumnType("datetime2");

                    b.Property<int>("CaixaTipo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fechamento")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorInicial")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("TB_Caixa");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Cama", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CamaTipo")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<Guid>("QuaroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("QuaroId");

                    b.ToTable("TB_Cama");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_Cargo");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_Categoria");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("TB_Cidade");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EmailTipo")
                        .HasColumnType("int");

                    b.Property<string>("EnderecoEmail")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HospedeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("HospedeId");

                    b.ToTable("TB_Email");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("CidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HospedeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Referencia")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("HospedeId");

                    b.ToTable("TB_Endereco");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_Estado");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Foto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnuncioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Caminho")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AnuncioId");

                    b.ToTable("TB_Foto");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CargoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<Guid>("GrupoFuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("GrupoFuncionarioId");

                    b.ToTable("TB_Funcionario");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.GrupoFuncionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_GrupoFuncionario");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Hospede", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("ResponsavelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("TB_Hospede");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.ItensVenda", b =>
                {
                    b.Property<Guid>("OrderVendaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("OrderVendaId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensVenda");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.OrderVenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CaixaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Instante")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuantidadeTotal")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CaixaId");

                    b.ToTable("TB_OrderVenda");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoBarras")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeVendida")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("TB_Produto");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Quarto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("FrigobarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Hidromassagem")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("NumeroQuarto")
                        .HasColumnType("int");

                    b.Property<bool>("Ocupado")
                        .HasColumnType("bit");

                    b.Property<bool>("Televisor")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_Quarto");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Reserva", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnuncioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CustoAdicional")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("HospedeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorReserva")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AnuncioId");

                    b.HasIndex("HospedeId");

                    b.ToTable("TB_Reserva");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Telefone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.Property<Guid?>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HospedeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.Property<int>("TelefoneTipo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("HospedeId");

                    b.ToTable("TB_Telefone");
                });

            modelBuilder.Entity("UnipPim.Hotel.Pagamento.Dominio.Models.Pagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CvvCartao")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ExpiracaoCartao")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCartao")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NumeroCartao")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("UnipPim.Hotel.Pagamento.Dominio.Models.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PagamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StatusTransacao")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId")
                        .IsUnique();

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Acesso", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.GrupoFuncionario", null)
                        .WithMany("Acesso")
                        .HasForeignKey("GrupoFuncionarioId");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Anuncio", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .IsRequired();

                    b.HasOne("UnipPim.Hotel.Dominio.Models.Quarto", "Quarto")
                        .WithMany("Anuncios")
                        .HasForeignKey("QuartoId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Caixa", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Funcionario", "Funcionario")
                        .WithMany("Caixas")
                        .HasForeignKey("FuncionarioId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Cama", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Quarto", "Quarto")
                        .WithMany("Camas")
                        .HasForeignKey("QuaroId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Cidade", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Email", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Funcionario", "Funcionario")
                        .WithMany("Emails")
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("UnipPim.Hotel.Dominio.Models.Hospede", "Hospede")
                        .WithMany("Emails")
                        .HasForeignKey("HospedeId");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Endereco", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("CidadeId")
                        .IsRequired();

                    b.HasOne("UnipPim.Hotel.Dominio.Models.Funcionario", "Funcionario")
                        .WithMany("Enderecos")
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("UnipPim.Hotel.Dominio.Models.Hospede", "Hospede")
                        .WithMany("Enderecos")
                        .HasForeignKey("HospedeId");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Foto", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Anuncio", "Anuncio")
                        .WithMany("Fotos")
                        .HasForeignKey("AnuncioId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Funcionario", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Cargo", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId")
                        .IsRequired();

                    b.HasOne("UnipPim.Hotel.Dominio.Models.GrupoFuncionario", "GrupoFuncionario")
                        .WithMany("Funcionarios")
                        .HasForeignKey("GrupoFuncionarioId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Hospede", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Hospede", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId");
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.ItensVenda", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.OrderVenda", "OrderVenda")
                        .WithMany("ItensVendas")
                        .HasForeignKey("OrderVendaId")
                        .IsRequired();

                    b.HasOne("UnipPim.Hotel.Dominio.Models.Produto", "Produto")
                        .WithMany("ItensVendas")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.OrderVenda", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Caixa", "Caixa")
                        .WithMany("OrderVendas")
                        .HasForeignKey("CaixaId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Produto", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Reserva", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Anuncio", "Anuncio")
                        .WithMany("Reservas")
                        .HasForeignKey("AnuncioId")
                        .IsRequired();

                    b.HasOne("UnipPim.Hotel.Dominio.Models.Hospede", "Hospede")
                        .WithMany()
                        .HasForeignKey("HospedeId")
                        .IsRequired();
                });

            modelBuilder.Entity("UnipPim.Hotel.Dominio.Models.Telefone", b =>
                {
                    b.HasOne("UnipPim.Hotel.Dominio.Models.Funcionario", "Funcionario")
                        .WithMany("Telefones")
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("UnipPim.Hotel.Dominio.Models.Hospede", "Hospede")
                        .WithMany("Telefones")
                        .HasForeignKey("HospedeId");
                });

            modelBuilder.Entity("UnipPim.Hotel.Pagamento.Dominio.Models.Transacao", b =>
                {
                    b.HasOne("UnipPim.Hotel.Pagamento.Dominio.Models.Pagamento", "Pagamento")
                        .WithOne("Transacao")
                        .HasForeignKey("UnipPim.Hotel.Pagamento.Dominio.Models.Transacao", "PagamentoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
