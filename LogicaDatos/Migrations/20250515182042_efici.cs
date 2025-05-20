using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class efici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eficiencia",
                table: "Envios");

            migrationBuilder.AddColumn<bool>(
                name: "EntregaEficiente",
                table: "Envios",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntregaEficiente",
                table: "Envios");

            migrationBuilder.AddColumn<double>(
                name: "Eficiencia",
                table: "Envios",
                type: "float",
                nullable: true);
        }
    }
}
