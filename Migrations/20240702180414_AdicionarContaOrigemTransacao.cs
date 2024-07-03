using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarContaOrigemTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "ContaOrigemID",
            table: "Transacoes",
            nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaOrigemID",
                table: "Transacoes",
                column: "ContaOrigemID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaOrigemID",
                table: "Transacoes",
                column: "ContaOrigemID",
                principalTable: "Contas",
                principalColumn: "ContaID",
                onDelete: ReferentialAction.Cascade
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
