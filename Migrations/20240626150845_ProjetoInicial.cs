using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class ProjetoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosContas",
                columns: table => new
                {
                    Conta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Saldo = table.Column<double>(type: "float", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosContas", x => x.Conta);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosContas");
        }
    }
}
