namespace proyecto.Models.DTO
{
    public class DtoCotizacion
    {
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string TipoDocumento { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }

        public List<DtoProducto> listaProductos { get; set; }
    }
}
