namespace proyecto.Models.DTO
{
    public class DtoRolPermiso
    {
        public int? IdRol { get; set; }
        public int? IdPermiso { get; set; }
        public int? IdRolPermiso { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public bool Checked { get; set; }
        public List<DtoRolPermiso>? RolPermisos { get; set; }
    }
}
