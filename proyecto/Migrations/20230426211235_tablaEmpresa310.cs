using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class tablaEmpresa310 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "VentaCredito",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Venta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Cotizacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Compra",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentaCredito_IdEmpresa",
                table: "VentaCredito",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdEmpresa",
                table: "Venta",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_IdEmpresa",
                table: "Cotizacion",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdEmpresa",
                table: "Compra",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Empresa_IdEmpresa",
                table: "Compra",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizacion_Empresa_IdEmpresa",
                table: "Cotizacion",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Empresa_IdEmpresa",
                table: "Venta",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaCredito_Empresa_IdEmpresa",
                table: "VentaCredito",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Empresa_IdEmpresa",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Cotizacion_Empresa_IdEmpresa",
                table: "Cotizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Empresa_IdEmpresa",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaCredito_Empresa_IdEmpresa",
                table: "VentaCredito");

            migrationBuilder.DropIndex(
                name: "IX_VentaCredito_IdEmpresa",
                table: "VentaCredito");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdEmpresa",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Cotizacion_IdEmpresa",
                table: "Cotizacion");

            migrationBuilder.DropIndex(
                name: "IX_Compra_IdEmpresa",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "VentaCredito");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Cotizacion");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Compra");
        }
    }
}
