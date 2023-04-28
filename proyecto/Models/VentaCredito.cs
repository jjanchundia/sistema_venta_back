using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class VentaCredito
    {
        [Key]
        public int IdVentaCredito { get; set; }
        public string? TipoVenta { get; set; }
        public string? NumeroTarjeta { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public string? CodigoSeguridad { get; set; }        
        public decimal CuotaInicial { get; set; }
        public int CantidadMeses { get; set; }
        public int? CuotasPagadas { get; set; }
        public bool? EsCancelada { get; set; }
        public decimal CuotaMensual { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual Empresa? Empresa { get; set; }
        public virtual ICollection<DetalleVentaCredito>? DetalleVentaCredito { get; set; }
    }
}
