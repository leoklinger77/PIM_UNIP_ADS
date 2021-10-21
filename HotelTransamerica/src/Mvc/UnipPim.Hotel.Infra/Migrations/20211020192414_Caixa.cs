using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnipPim.Hotel.Infra.Migrations
{
    public partial class Caixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Caixa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    FuncionarioId = table.Column<Guid>(nullable: false),
                    ValorInicial = table.Column<decimal>(nullable: false),
                    Abertura = table.Column<DateTime>(nullable: false),
                    Fechamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Caixa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_OrderVenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Instante = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(type: "varchar(255)", nullable: true),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    QuantidadeTotal = table.Column<int>(nullable: false),
                    CaixaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_OrderVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_OrderVenda_TB_Caixa_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "TB_Caixa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensVenda",
                columns: table => new
                {
                    OrderVendaId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    PrecoVenda = table.Column<decimal>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVenda", x => new { x.OrderVendaId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_ItensVenda_TB_OrderVenda_OrderVendaId",
                        column: x => x.OrderVendaId,
                        principalTable: "TB_OrderVenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItensVenda_TB_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "TB_Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_ProdutoId",
                table: "ItensVenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_OrderVenda_CaixaId",
                table: "TB_OrderVenda",
                column: "CaixaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensVenda");

            migrationBuilder.DropTable(
                name: "TB_OrderVenda");

            migrationBuilder.DropTable(
                name: "TB_Caixa");
        }
    }
}
