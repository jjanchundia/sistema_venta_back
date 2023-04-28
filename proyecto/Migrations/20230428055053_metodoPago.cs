using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class metodoPago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoSeguridad",
                table: "VentaCredito",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCaducidad",
                table: "VentaCredito",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTarjeta",
                table: "VentaCredito",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoVenta",
                table: "VentaCredito",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoSeguridad",
                table: "Venta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCaducidad",
                table: "Venta",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdNumeroDocumento",
                table: "Venta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTarjeta",
                table: "Venta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoVenta",
                table: "Venta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdNumeroDocumento",
                table: "Venta",
                column: "IdNumeroDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_NumeroDocumento_IdNumeroDocumento",
                table: "Venta",
                column: "IdNumeroDocumento",
                principalTable: "NumeroDocumento",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_NumeroDocumento_IdNumeroDocumento",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdNumeroDocumento",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "CodigoSeguridad",
                table: "VentaCredito");

            migrationBuilder.DropColumn(
                name: "FechaCaducidad",
                table: "VentaCredito");

            migrationBuilder.DropColumn(
                name: "NumeroTarjeta",
                table: "VentaCredito");

            migrationBuilder.DropColumn(
                name: "TipoVenta",
                table: "VentaCredito");

            migrationBuilder.DropColumn(
                name: "CodigoSeguridad",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "FechaCaducidad",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "IdNumeroDocumento",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "NumeroTarjeta",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "TipoVenta",
                table: "Venta");
        }
    }
}
