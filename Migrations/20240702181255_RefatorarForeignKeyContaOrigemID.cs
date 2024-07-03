using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class RefatorarForeignKeyContaOrigemID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey
                (
                name: "FK_ContaOrigemID",
                table: "Transacoes"
                );

            migrationBuilder.AddForeignKey(
            name: "FK_ContaOrigemID",
            table: "Transacoes",
            column: "ContaOrigemID",
            principalTable: "Contas",
            principalColumn: "ContaID"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
