using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnipPim.Hotel.Infra.Migrations
{
    public partial class QuartoAnuncio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncio_TB_Funcionario_FuncionarioId",
                table: "Anuncio");

            migrationBuilder.DropForeignKey(
                name: "FK_Anuncio_Quarto_QuartoId",
                table: "Anuncio");

            migrationBuilder.DropForeignKey(
                name: "FK_Cama_Quarto_QuartoId",
                table: "Cama");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Anuncio_AnuncioId",
                table: "Foto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quarto",
                table: "Quarto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foto",
                table: "Foto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cama",
                table: "Cama");

            migrationBuilder.DropIndex(
                name: "IX_Cama_QuartoId",
                table: "Cama");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anuncio",
                table: "Anuncio");

            migrationBuilder.DropColumn(
                name: "QuartoId",
                table: "Cama");

            migrationBuilder.RenameTable(
                name: "Quarto",
                newName: "TB_Quarto");

            migrationBuilder.RenameTable(
                name: "Foto",
                newName: "TB_Foto");

            migrationBuilder.RenameTable(
                name: "Cama",
                newName: "TB_Cama");

            migrationBuilder.RenameTable(
                name: "Anuncio",
                newName: "TB_Anuncio");

            migrationBuilder.RenameIndex(
                name: "IX_Foto_AnuncioId",
                table: "TB_Foto",
                newName: "IX_TB_Foto_AnuncioId");

            migrationBuilder.RenameIndex(
                name: "IX_Anuncio_QuartoId",
                table: "TB_Anuncio",
                newName: "IX_TB_Anuncio_QuartoId");

            migrationBuilder.RenameIndex(
                name: "IX_Anuncio_FuncionarioId",
                table: "TB_Anuncio",
                newName: "IX_TB_Anuncio_FuncionarioId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnuncioId",
                table: "TB_Foto",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Quarto",
                table: "TB_Quarto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Foto",
                table: "TB_Foto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Cama",
                table: "TB_Cama",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Anuncio",
                table: "TB_Anuncio",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Cama_QuaroId",
                table: "TB_Cama",
                column: "QuaroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Anuncio_TB_Funcionario_FuncionarioId",
                table: "TB_Anuncio",
                column: "FuncionarioId",
                principalTable: "TB_Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Anuncio_TB_Quarto_QuartoId",
                table: "TB_Anuncio",
                column: "QuartoId",
                principalTable: "TB_Quarto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Cama_TB_Quarto_QuaroId",
                table: "TB_Cama",
                column: "QuaroId",
                principalTable: "TB_Quarto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Foto_TB_Anuncio_AnuncioId",
                table: "TB_Foto",
                column: "AnuncioId",
                principalTable: "TB_Anuncio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Anuncio_TB_Funcionario_FuncionarioId",
                table: "TB_Anuncio");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Anuncio_TB_Quarto_QuartoId",
                table: "TB_Anuncio");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Cama_TB_Quarto_QuaroId",
                table: "TB_Cama");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Foto_TB_Anuncio_AnuncioId",
                table: "TB_Foto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Quarto",
                table: "TB_Quarto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Foto",
                table: "TB_Foto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Cama",
                table: "TB_Cama");

            migrationBuilder.DropIndex(
                name: "IX_TB_Cama_QuaroId",
                table: "TB_Cama");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Anuncio",
                table: "TB_Anuncio");

            migrationBuilder.RenameTable(
                name: "TB_Quarto",
                newName: "Quarto");

            migrationBuilder.RenameTable(
                name: "TB_Foto",
                newName: "Foto");

            migrationBuilder.RenameTable(
                name: "TB_Cama",
                newName: "Cama");

            migrationBuilder.RenameTable(
                name: "TB_Anuncio",
                newName: "Anuncio");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Foto_AnuncioId",
                table: "Foto",
                newName: "IX_Foto_AnuncioId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Anuncio_QuartoId",
                table: "Anuncio",
                newName: "IX_Anuncio_QuartoId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Anuncio_FuncionarioId",
                table: "Anuncio",
                newName: "IX_Anuncio_FuncionarioId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnuncioId",
                table: "Foto",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "QuartoId",
                table: "Cama",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quarto",
                table: "Quarto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foto",
                table: "Foto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cama",
                table: "Cama",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anuncio",
                table: "Anuncio",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cama_QuartoId",
                table: "Cama",
                column: "QuartoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncio_TB_Funcionario_FuncionarioId",
                table: "Anuncio",
                column: "FuncionarioId",
                principalTable: "TB_Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncio_Quarto_QuartoId",
                table: "Anuncio",
                column: "QuartoId",
                principalTable: "Quarto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cama_Quarto_QuartoId",
                table: "Cama",
                column: "QuartoId",
                principalTable: "Quarto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Anuncio_AnuncioId",
                table: "Foto",
                column: "AnuncioId",
                principalTable: "Anuncio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
