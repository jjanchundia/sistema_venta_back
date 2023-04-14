using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class Cotizacion
    {
        [Key]
        public int IdCotizacion { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuario { get; set; }
        public int IdCliente { get; set; }
        //public string? DocumentoCliente { get; set; }
        //public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }
        [ForeignKey("IdCotizacion")]
        public virtual Cliente? Cliente { get; set; }
        //[ForeignKey("IdDetalleCotizacion")]
        public virtual ICollection<DetalleCotizacion>? DetalleCotizacion { get; set; }
    }
}
