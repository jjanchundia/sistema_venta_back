namespace proyecto.Models.DTO
{
    public class DtoVenta
    {
        public string tipoDocumento { get; set; }
        public int idUsuario { get; set; }
        public int IdCliente { get; set; }
        public decimal subTotal { get; set; }
        public decimal igv { get; set; }
        public decimal total { get; set; }

        public List<DtoProducto> listaProductos { get; set; }
    }
}
