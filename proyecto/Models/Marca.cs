using System.ComponentModel.DataAnnotations;

namespace proyecto.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
    }
}
