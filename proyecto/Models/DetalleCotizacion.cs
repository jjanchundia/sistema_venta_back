using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class DetalleCotizacion
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalleCotizacion { get; set; }
        public int? IdCotizacion { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
        [ForeignKey("IdProducto")]
        public virtual Producto? Producto { get; set; }
        [ForeignKey("IdCotizacion")]
        public virtual Cotizacion? Cotizacion { get; set; }
    }
}
