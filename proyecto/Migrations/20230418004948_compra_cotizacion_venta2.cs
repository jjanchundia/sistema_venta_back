using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class compra_cotizacion_venta2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Proveedor_IdCliente",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_IdCliente",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Compra");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdProveedor",
                table: "Compra",
                column: "IdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Proveedor_IdProveedor",
                table: "Compra",
                column: "IdProveedor",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Proveedor_IdProveedor",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_IdProveedor",
                table: "Compra");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Compra",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdCliente",
                table: "Compra",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Proveedor_IdCliente",
                table: "Compra",
                column: "IdCliente",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor");
        }
    }
}
