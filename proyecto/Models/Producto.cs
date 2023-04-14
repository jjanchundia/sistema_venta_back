using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int IdProducto { get; set; }
        public string? Codigo { get; set; }
        //public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdMarca { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        [ForeignKey("IdMarca")]
        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual Categoria? IdCategoriaNavigation { get; set; }
        public virtual ICollection<DetalleVenta>? DetalleVenta { get; set; }
        public virtual ICollection<DetalleCompra>? DetalleCompra { get; set; }
    }
}
