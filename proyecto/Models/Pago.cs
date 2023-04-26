using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class Pago
    {
        [Key]
        public int IdPago { get; set; }
        public int CuotaPagar { get; set; }
        public decimal ValorPagar{ get; set; }
        public decimal SaldoPendiente { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int IdVentaCredito { get; set; }
        [ForeignKey("IdVentaCredito")]
        public virtual VentaCredito? VentaCredito { get; set; }
    }
}
