using System.ComponentModel.DataAnnotations;

namespace proyecto.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc_Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
