using Microsoft.EntityFrameworkCore.Migrations;

namespace UnipPim.Hotel.Infra.Migrations
{
    public partial class CepEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "TB_Endereco",
                type: "varchar(255)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "TB_Endereco");
        }
    }
}
