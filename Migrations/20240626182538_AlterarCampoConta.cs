using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class AlterarCampoConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("Conta", "Contas", "ContaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
