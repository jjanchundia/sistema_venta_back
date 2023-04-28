namespace proyecto.Models.DTO
{
    public class DtoPago
    {
        public int IdVentaCredito { get; set; }
        public int? IdCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? TipoDocumento { get; set; }

        public string? FechaRegistro { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? UsuarioRegistro { get; set; }
        //public string? SubTotal { get; set; }
        //public string? Impuesto { get; set; }
        public string? Total { get; set; }
        public string? SubTotalVenta { get; set; }
        public string? ImpuestoTotalVenta { get; set; }
        public string? TotalVenta { get; set; }
        public string? Producto { get; set; }
        public string? Cantidad { get; set; }
        public string? Precio { get; set; }
        public string? ValorInicial { get; set; }
        public string? CuotaMensual { get; set; }
        public string? CuotaPendientes { get; set; }        
        public string? Cuotas { get; set; }
        public int CuotaPagar { get; set; }
        public decimal ValorPagar { get; set; }
        public decimal SaldoPendiente { get; set; }
        public List<DtoDetalleVentaCredito>? Detalle { get; set; }
        public Empresa? Empresa { get; set; }
    }
}
