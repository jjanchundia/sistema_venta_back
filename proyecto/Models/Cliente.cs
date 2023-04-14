using System.ComponentModel.DataAnnotations;

namespace proyecto.Models
{
    public partial class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        //public virtual ICollection<Compra>? Compra { get; set; }
        //public virtual ICollection<Cotizacion>? Cotizacion { get; set; }
    }
}
