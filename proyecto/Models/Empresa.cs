using System.ComponentModel.DataAnnotations;

namespace proyecto.Models
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        public string RucDocumento { get; set; }
        public string Nombre{ get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
