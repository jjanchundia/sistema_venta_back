using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    public partial class ventaCredito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VentaCredito",
                columns: table => new
                {
                    IdVentaCredito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuotaInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadMeses = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CuotaMensual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImpuestoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaCredito", x => x.IdVentaCredito);
                    table.ForeignKey(
                        name: "FK_VentaCredito_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaCredito_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVentaCredito",
                columns: table => new
                {
                    IdDetalleVentaCredito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVentaCredito = table.Column<int>(type: "int", nullable: true),
                    IdProducto = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVentaCredito", x => x.IdDetalleVentaCredito);
                    table.ForeignKey(
                        name: "FK_DetalleVentaCredito_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto");
                    table.ForeignKey(
                        name: "FK_DetalleVentaCredito_VentaCredito_IdVentaCredito",
                        column: x => x.IdVentaCredito,
                        principalTable: "VentaCredito",
                        principalColumn: "IdVentaCredito");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentaCredito_IdProducto",
                table: "DetalleVentaCredito",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentaCredito_IdVentaCredito",
                table: "DetalleVentaCredito",
                column: "IdVentaCredito");

            migrationBuilder.CreateIndex(
                name: "IX_VentaCredito_IdCliente",
                table: "VentaCredito",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_VentaCredito_IdUsuario",
                table: "VentaCredito",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVentaCredito");

            migrationBuilder.DropTable(
                name: "VentaCredito");
        }
    }
}
