using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int IdVenta { get; set; }
        public string? TipoVenta { get; set; }
        public string? NumeroTarjeta { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public string? CodigoSeguridad { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdNumeroDocumento { get; set; }
        public int IdCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual Empresa? Empresa { get; set; }
        [ForeignKey("IdNumeroDocumento")]
        public virtual NumeroDocumento? NumeroDocumentoVenta { get; set; }
        public virtual ICollection<DetalleVenta>? DetalleVenta { get; set; }
    }
}
