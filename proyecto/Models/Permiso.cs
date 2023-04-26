using System.ComponentModel.DataAnnotations;

namespace proyecto.Models
{
    public partial class Permiso
    {
        [Key]
        public int IdPermiso { get; set; }
        public string NombrePermiso { get; set; }
        public string Descripcion { get; set; }
    }
}
