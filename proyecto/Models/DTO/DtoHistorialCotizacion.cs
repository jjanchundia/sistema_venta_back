﻿namespace proyecto.Models.DTO
{
    public class DtoHistorialCotizacion
    {
        public int? IdCotizacion { get; set; }
        public string? FechaRegistro { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? SubTotal { get; set; }
        public string? Impuesto { get; set; }
        public string? Total { get; set; }

        public List<DtoDetalleCotizacion> Detalle { get; set; }
        public Empresa? Empresa { get; set; }


    }
}
