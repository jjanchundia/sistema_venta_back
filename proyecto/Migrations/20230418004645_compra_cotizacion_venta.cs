using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class compra_cotizacion_venta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Cliente_IdCliente",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "documentoCliente",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "nombreCliente",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "RazonSocial",
                table: "Proveedor");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Compra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdProveedor",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdCliente",
                table: "Venta",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Proveedor_IdCliente",
                table: "Compra",
                column: "IdCliente",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Cliente_IdCliente",
                table: "Venta",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Proveedor_IdCliente",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Cliente_IdCliente",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdCliente",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "IdProveedor",
                table: "Compra");

            migrationBuilder.AddColumn<string>(
                name: "documentoCliente",
                table: "Venta",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombreCliente",
                table: "Venta",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazonSocial",
                table: "Proveedor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Cliente_IdCliente",
                table: "Compra",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
