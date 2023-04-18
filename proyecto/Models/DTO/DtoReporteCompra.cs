
namespace proyecto.Models.DTO
{
    public class DtoReporteCompra
    {
        public string FechaRegistro { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string SubTotalCompra { get; set; }
        public string ImpuestoTotalCompra { get; set; }
        public string TotalCompra { get; set; }
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string Total { get; set; }
    }
}