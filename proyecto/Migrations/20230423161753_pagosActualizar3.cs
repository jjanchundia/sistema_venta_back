using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class pagosActualizar3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Venta_IdVenta",
                table: "Pago");

            migrationBuilder.RenameColumn(
                name: "IdVenta",
                table: "Pago",
                newName: "IdVentaCredito");

            migrationBuilder.RenameIndex(
                name: "IX_Pago_IdVenta",
                table: "Pago",
                newName: "IX_Pago_IdVentaCredito");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_VentaCredito_IdVentaCredito",
                table: "Pago",
                column: "IdVentaCredito",
                principalTable: "VentaCredito",
                principalColumn: "IdVentaCredito",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_VentaCredito_IdVentaCredito",
                table: "Pago");

            migrationBuilder.RenameColumn(
                name: "IdVentaCredito",
                table: "Pago",
                newName: "IdVenta");

            migrationBuilder.RenameIndex(
                name: "IX_Pago_IdVentaCredito",
                table: "Pago",
                newName: "IX_Pago_IdVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Venta_IdVenta",
                table: "Pago",
                column: "IdVenta",
                principalTable: "Venta",
                principalColumn: "idVenta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
