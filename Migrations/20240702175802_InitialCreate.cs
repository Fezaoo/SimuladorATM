using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //    migrationBuilder.CreateTable(
            //        name: "Contas",
            //        columns: table => new
            //        {
            //            ContaID = table.Column<int>(type: "int", nullable: false)
            //                .Annotation("SqlServer:Identity", "1, 1"),
            //            Titular = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //            Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //            Saldo = table.Column<double>(type: "float", nullable: false),
            //            Agencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_Contas", x => x.ContaID);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "Transacoes",
            //        columns: table => new
            //        {
            //            TransacaoID = table.Column<int>(type: "int", nullable: false)
            //                .Annotation("SqlServer:Identity", "1, 1"),
            //            ContaID = table.Column<int>(type: "int", nullable: false),
            //            TipoTransacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //            Valor = table.Column<double>(type: "float", nullable: false),
            //            DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_Transacoes", x => x.TransacaoID);
            //        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Contas");

            //migrationBuilder.DropTable(
            //    name: "Transacoes");
        }
    }
}
