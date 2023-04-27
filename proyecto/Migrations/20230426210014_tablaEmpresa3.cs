using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class tablaEmpresa3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Cotizacion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_IdEmpresa",
                table: "Cotizacion",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizacion_Empresa_IdEmpresa",
                table: "Cotizacion",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizacion_Empresa_IdEmpresa",
                table: "Cotizacion");

            migrationBuilder.DropIndex(
                name: "IX_Cotizacion_IdEmpresa",
                table: "Cotizacion");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Cotizacion");
        }
    }
}
