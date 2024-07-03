using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class InsertValueNotExisting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.UpdateData
                    (
                    "Transacoes", "TransacaoID", 9, "ContaOrigemID", 10002
                    );
            }

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
