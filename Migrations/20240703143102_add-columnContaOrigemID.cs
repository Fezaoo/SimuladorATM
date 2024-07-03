using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorATM.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnContaOrigemID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaOrigemIDE",
                table: "Transacoes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaOrigemIDE",
                table: "Transacoes");
        }
    }
}
