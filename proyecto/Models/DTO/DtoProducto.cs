namespace proyecto.Models.DTO
{
    public class DtoProducto
    {
        public int IdProducto { get; set; }
        public string? Codigo { get; set; }
        public int? IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Total { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public bool? EsActivo { get; set; }
    }
}
