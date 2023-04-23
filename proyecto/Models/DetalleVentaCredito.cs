using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proyecto.Models
{
    public partial class DetalleVentaCredito
    {
        [Key]
        public int IdDetalleVentaCredito { get; set; }
        public int? IdVentaCredito { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
        [ForeignKey("IdProducto")]
        public virtual Producto? Producto { get; set; }
        [ForeignKey("IdVentaCredito")]
        public virtual VentaCredito? VentaCredito { get; set; }
    }
}
