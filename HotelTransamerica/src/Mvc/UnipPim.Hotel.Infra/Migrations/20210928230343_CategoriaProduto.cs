using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnipPim.Hotel.Infra.Migrations
{
    public partial class CategoriaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_TB_Produto_CategoriaId",
                table: "TB_Produto",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Produto");

            migrationBuilder.DropTable(
                name: "TB_Categoria");
        }
    }
}
