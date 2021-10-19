using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnipPim.Hotel.Infra.Migrations
{
    public partial class REserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_TB_Reserva_AnuncioId",
                table: "TB_Reserva",
                column: "AnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Reserva_HospedeId",
                table: "TB_Reserva",
                column: "HospedeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Reserva");
        }
    }
}
