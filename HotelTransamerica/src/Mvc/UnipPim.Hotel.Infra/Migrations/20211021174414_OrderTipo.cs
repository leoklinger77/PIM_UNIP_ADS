using Microsoft.EntityFrameworkCore.Migrations;

namespace UnipPim.Hotel.Infra.Migrations
{
    public partial class OrderTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "TB_OrderVenda",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "TB_OrderVenda");
        }
    }
}
