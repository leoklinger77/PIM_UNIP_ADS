using Microsoft.EntityFrameworkCore.Migrations;

namespace UnipPim.Hotel.Infra.Migrations
{
    public partial class Quarto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "TB_Quarto",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroQuarto",
                table: "TB_Quarto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Ocupado",
                table: "TB_Quarto",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "TB_Cama",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "TB_Anuncio",
                type: "varchar(255)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "TB_Quarto");

            migrationBuilder.DropColumn(
                name: "NumeroQuarto",
                table: "TB_Quarto");

            migrationBuilder.DropColumn(
                name: "Ocupado",
                table: "TB_Quarto");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "TB_Cama");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "TB_Anuncio");
        }
    }
}
