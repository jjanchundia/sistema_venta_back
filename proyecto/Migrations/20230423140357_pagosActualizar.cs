using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class pagosActualizar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuotasPagadas",
                table: "VentaCredito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EsCancelada",
                table: "VentaCredito",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CuotaPagar",
                table: "Pago",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Pago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPagar",
                table: "Pago",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuotasPagadas",
                table: "VentaCredito");

            migrationBuilder.DropColumn(
                name: "EsCancelada",
                table: "VentaCredito");

            migrationBuilder.DropColumn(
                name: "CuotaPagar",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "ValorPagar",
                table: "Pago");
        }
    }
}
