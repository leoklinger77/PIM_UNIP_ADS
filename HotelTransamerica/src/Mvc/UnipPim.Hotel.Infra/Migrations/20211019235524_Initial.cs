using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnipPim.Hotel.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Cargo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Estado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Uf = table.Column<string>(type: "char(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_GrupoFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GrupoFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Hospede",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    NomeCompleto = table.Column<string>(type: "varchar(255)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Hospede", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Quarto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    FrigobarId = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: true),
                    Televisor = table.Column<bool>(nullable: false),
                    Hidromassagem = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: true),
                    NumeroQuarto = table.Column<int>(nullable: false),
                    Ocupado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Quarto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CategoriaId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: true),
                    CodigoBarras = table.Column<string>(type: "varchar(255)", nullable: true),
                    QuantidadeEstoque = table.Column<int>(nullable: false),
                    QuantidadeVendida = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Produto_TB_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TB_Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Cidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    EstadoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Cidade_TB_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "TB_Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Acesso",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ClaimType = table.Column<string>(type: "varchar(50)", nullable: false),
                    ClaimValue = table.Column<string>(type: "varchar(255)", nullable: false),
                    GrupoFuncionarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Acesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Acesso_TB_GrupoFuncionario_GrupoFuncionarioId",
                        column: x => x.GrupoFuncionarioId,
                        principalTable: "TB_GrupoFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CargoId = table.Column<Guid>(nullable: false),
                    GrupoFuncionarioId = table.Column<Guid>(nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(255)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Funcionario_TB_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "TB_Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Funcionario_TB_GrupoFuncionario_GrupoFuncionarioId",
                        column: x => x.GrupoFuncionarioId,
                        principalTable: "TB_GrupoFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Dependente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    NomeCompleto = table.Column<string>(type: "varchar(255)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    ResponsavelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Dependente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Dependente_TB_Hospede_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "TB_Hospede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Cama",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    QuaroId = table.Column<Guid>(nullable: false),
                    CamaTipo = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cama", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Cama_TB_Quarto_QuaroId",
                        column: x => x.QuaroId,
                        principalTable: "TB_Quarto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Anuncio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    FuncionarioId = table.Column<Guid>(nullable: false),
                    QuartoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Custo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Anuncio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Anuncio_TB_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TB_Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Anuncio_TB_Quarto_QuartoId",
                        column: x => x.QuartoId,
                        principalTable: "TB_Quarto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    EnderecoEmail = table.Column<string>(type: "varchar(255)", nullable: true),
                    EmailTipo = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: true),
                    HospedeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Email_TB_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TB_Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Email_TB_Hospede_HospedeId",
                        column: x => x.HospedeId,
                        principalTable: "TB_Hospede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Cep = table.Column<string>(type: "varchar(255)", nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(255)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(255)", nullable: true),
                    Referencia = table.Column<string>(type: "varchar(255)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    CidadeId = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: true),
                    HospedeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Endereco_TB_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "TB_Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Endereco_TB_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TB_Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Endereco_TB_Hospede_HospedeId",
                        column: x => x.HospedeId,
                        principalTable: "TB_Hospede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Telefone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Ddd = table.Column<string>(type: "char(2)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(9)", nullable: false),
                    TelefoneTipo = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: true),
                    HospedeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Telefone_TB_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TB_Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Telefone_TB_Hospede_HospedeId",
                        column: x => x.HospedeId,
                        principalTable: "TB_Hospede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Foto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AnuncioId = table.Column<Guid>(nullable: false),
                    Caminho = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Foto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Foto_TB_Anuncio_AnuncioId",
                        column: x => x.AnuncioId,
                        principalTable: "TB_Anuncio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Reserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AnuncioId = table.Column<Guid>(nullable: false),
                    HospedeId = table.Column<Guid>(nullable: false),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    CustoAdicional = table.Column<decimal>(nullable: false),
                    ValorReserva = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Reserva_TB_Anuncio_AnuncioId",
                        column: x => x.AnuncioId,
                        principalTable: "TB_Anuncio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Reserva_TB_Hospede_HospedeId",
                        column: x => x.HospedeId,
                        principalTable: "TB_Hospede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Acesso_GrupoFuncionarioId",
                table: "TB_Acesso",
                column: "GrupoFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Anuncio_FuncionarioId",
                table: "TB_Anuncio",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Anuncio_QuartoId",
                table: "TB_Anuncio",
                column: "QuartoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Cama_QuaroId",
                table: "TB_Cama",
                column: "QuaroId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Cidade_EstadoId",
                table: "TB_Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Dependente_ResponsavelId",
                table: "TB_Dependente",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Email_FuncionarioId",
                table: "TB_Email",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Email_HospedeId",
                table: "TB_Email",
                column: "HospedeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Endereco_CidadeId",
                table: "TB_Endereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Endereco_FuncionarioId",
                table: "TB_Endereco",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Endereco_HospedeId",
                table: "TB_Endereco",
                column: "HospedeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Foto_AnuncioId",
                table: "TB_Foto",
                column: "AnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Funcionario_CargoId",
                table: "TB_Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Funcionario_GrupoFuncionarioId",
                table: "TB_Funcionario",
                column: "GrupoFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Produto_CategoriaId",
                table: "TB_Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Reserva_AnuncioId",
                table: "TB_Reserva",
                column: "AnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Reserva_HospedeId",
                table: "TB_Reserva",
                column: "HospedeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Telefone_FuncionarioId",
                table: "TB_Telefone",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Telefone_HospedeId",
                table: "TB_Telefone",
                column: "HospedeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Acesso");

            migrationBuilder.DropTable(
                name: "TB_Cama");

            migrationBuilder.DropTable(
                name: "TB_Dependente");

            migrationBuilder.DropTable(
                name: "TB_Email");

            migrationBuilder.DropTable(
                name: "TB_Endereco");

            migrationBuilder.DropTable(
                name: "TB_Foto");

            migrationBuilder.DropTable(
                name: "TB_Produto");

            migrationBuilder.DropTable(
                name: "TB_Reserva");

            migrationBuilder.DropTable(
                name: "TB_Telefone");

            migrationBuilder.DropTable(
                name: "TB_Cidade");

            migrationBuilder.DropTable(
                name: "TB_Categoria");

            migrationBuilder.DropTable(
                name: "TB_Anuncio");

            migrationBuilder.DropTable(
                name: "TB_Hospede");

            migrationBuilder.DropTable(
                name: "TB_Estado");

            migrationBuilder.DropTable(
                name: "TB_Funcionario");

            migrationBuilder.DropTable(
                name: "TB_Quarto");

            migrationBuilder.DropTable(
                name: "TB_Cargo");

            migrationBuilder.DropTable(
                name: "TB_GrupoFuncionario");
        }
    }
}
