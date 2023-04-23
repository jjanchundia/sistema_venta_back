using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class Pago
    {
        [Key]
        public int IdPago { get; set; }
        public decimal SaldoPendiente { get; set; }        
        public int IdVenta { get; set; }
        [ForeignKey("IdVenta")]
        public virtual Venta? Venta { get; set; }
    }
}
