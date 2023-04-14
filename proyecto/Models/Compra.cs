﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class Compra
    {
        //public Compra()
        //{
        //    DetalleCompra= new HashSet<DetalleCompra>();
        //}
        [Key]
        public int IdCompra { get; set; }
        public string? NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.Now;
        public int? IdUsuario { get; set; }
        public int IdCliente { get; set; }
        //public string? DocumentoCliente { get; set; }
        //public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }
        //[ForeignKey("IdDetalleCompra")]
        public virtual ICollection<DetalleCompra>? DetalleCompra { get; set; }
    }
}
