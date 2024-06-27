using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class InserirDadosConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("DadosContas", new string[] { "Conta", "Titular", "Senha", "Agencia", "Saldo"}, new object[] { 10002, "Felipe", "1234", "1", 100});
            migrationBuilder.InsertData("DadosContas", new string[] { "Conta", "Titular", "Senha", "Agencia", "Saldo"}, new object[] { 10003, "Matheus", "1234", "1", 100});
            migrationBuilder.InsertData("DadosContas", new string[] { "Conta", "Titular", "Senha", "Agencia", "Saldo"}, new object[] { 10004, "Juan", "1234", "1", 100});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
