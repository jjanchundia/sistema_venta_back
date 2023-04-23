using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class tablaPagosUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdVenta",
                table: "Pago",
                column: "IdVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Venta_IdVenta",
                table: "Pago",
                column: "IdVenta",
                principalTable: "Venta",
                principalColumn: "idVenta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Venta_IdVenta",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Pago_IdVenta",
                table: "Pago");
        }
    }
}
