using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class fjadsfjas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguimientos_Empleados_EmpleadoId",
                table: "Seguimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguimientos_Envios_EnvioId",
                table: "Seguimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguimientos_Empleados_EmpleadoId",
                table: "Seguimientos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seguimientos_Envios_EnvioId",
                table: "Seguimientos",
                column: "EnvioId",
                principalTable: "Envios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguimientos_Empleados_EmpleadoId",
                table: "Seguimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguimientos_Envios_EnvioId",
                table: "Seguimientos");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguimientos_Empleados_EmpleadoId",
                table: "Seguimientos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seguimientos_Envios_EnvioId",
                table: "Seguimientos",
                column: "EnvioId",
                principalTable: "Envios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
