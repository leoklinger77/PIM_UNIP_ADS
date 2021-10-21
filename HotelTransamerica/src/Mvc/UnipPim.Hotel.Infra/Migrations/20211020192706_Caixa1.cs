using Microsoft.EntityFrameworkCore.Migrations;

namespace UnipPim.Hotel.Infra.Migrations
{
    public partial class Caixa1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TB_Caixa_FuncionarioId",
                table: "TB_Caixa",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Caixa_TB_Funcionario_FuncionarioId",
                table: "TB_Caixa",
                column: "FuncionarioId",
                principalTable: "TB_Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Caixa_TB_Funcionario_FuncionarioId",
                table: "TB_Caixa");

            migrationBuilder.DropIndex(
                name: "IX_TB_Caixa_FuncionarioId",
                table: "TB_Caixa");
        }
    }
}
