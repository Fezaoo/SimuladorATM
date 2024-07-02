using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class RefatoracaoTabelaContas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DadosContas",
                table: "DadosContas");

            migrationBuilder.RenameTable(
                name: "DadosContas",
                newName: "Contas");

            migrationBuilder.RenameColumn(
                name: "Conta",
                table: "Contas",
                newName: "ContaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                table: "Contas",
                column: "ContaID");

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    TransacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaID = table.Column<int>(type: "int", nullable: false),
                    TipoTransacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.TransacaoID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                table: "Contas");

            migrationBuilder.RenameTable(
                name: "Contas",
                newName: "DadosContas");

            migrationBuilder.RenameColumn(
                name: "ContaID",
                table: "DadosContas",
                newName: "Conta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DadosContas",
                table: "DadosContas",
                column: "Conta");
        }
    }
}
