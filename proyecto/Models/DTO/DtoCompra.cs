namespace proyecto.Models.DTO
{
    public class DtoCompra
    {
        public string TipoDocumento { get; set; }
        public int IdUsuario { get; set; }
        public int IdProveedor { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }

        public List<DtoProducto> listaProductos { get; set; }
    }
}
