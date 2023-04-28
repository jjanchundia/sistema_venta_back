namespace proyecto.Models.DTO
{
    public class DtoVenta
    {
        public string? TipoVenta { get; set; }
        public string? NumeroTarjeta { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public string? CodigoSeguridad { get; set; }
        public decimal CuotaInicial { get; set; }
        public int CantidadMeses { get; set; }
        public decimal CuotaMensual { get; set; }
        public string tipoDocumento { get; set; }
        public int idUsuario { get; set; }
        public int IdCliente { get; set; }
        public decimal subTotal { get; set; }
        public decimal igv { get; set; }
        public decimal total { get; set; }

        public List<DtoProducto> listaProductos { get; set; }
    }
}
