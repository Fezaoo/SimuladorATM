using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class AlterarNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name:"DadosContas", newName:"Contas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
