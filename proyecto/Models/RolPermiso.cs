using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Models
{
    public partial class RolPermiso
    {
        [Key]
        public int IdRolPermiso { get; set; }
        public int? IdRol { get; set; }
        public int? IdPermiso { get; set; }
        [ForeignKey("IdPermiso")]
        public virtual Permiso? Permiso { get; set; }
        [ForeignKey("IdRol")]
        public virtual Rol? Rol { get; set; }

    }
}
