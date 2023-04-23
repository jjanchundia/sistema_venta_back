
namespace proyecto.Models.DTO
{
    public class DtoHistorialCompra
    {
        public string? FechaRegistro { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public string? DocumentoProveedor { get; set; }
        public string? NombreProveedor { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? SubTotal { get; set; }
        public string? Impuesto { get; set; }
        public string? Total { get; set; }
        public List<DtoDetalleCompra> Detalle { get; set; }
    }
}