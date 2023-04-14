namespace proyecto.Models.DTO
{
    public class DtoReporteCotizacion
    {
        public string FechaRegistro { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string SubTotalCotizacion { get; set; }
        public string ImpuestoTotalCotizacion { get; set; }
        public string TotalCotizacion { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string Total { get; set; }

    }
}
