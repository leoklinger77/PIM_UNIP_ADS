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
                name: "TB_Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CargoId = table.Column<Guid>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_TB_Cidade_EstadoId",
                table: "TB_Cidade",
                column: "EstadoId");

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
                name: "IX_TB_Funcionario_CargoId",
                table: "TB_Funcionario",
                column: "CargoId");

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
                name: "TB_Email");

            migrationBuilder.DropTable(
                name: "TB_Endereco");

            migrationBuilder.DropTable(
                name: "TB_Telefone");

            migrationBuilder.DropTable(
                name: "TB_Cidade");

            migrationBuilder.DropTable(
                name: "TB_Funcionario");

            migrationBuilder.DropTable(
                name: "TB_Hospede");

            migrationBuilder.DropTable(
                name: "TB_Estado");

            migrationBuilder.DropTable(
                name: "TB_Cargo");
        }
    }
}
