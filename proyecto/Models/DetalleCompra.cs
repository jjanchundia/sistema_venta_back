using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class DetalleCompra
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalleCompra { get; set; }
        public int? IdCompra { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
        [ForeignKey("IdProducto")]
        public virtual Producto? Producto { get; set; }
        [ForeignKey("IdCompra")]
        public virtual Compra? Compra { get; set; }
    }
}