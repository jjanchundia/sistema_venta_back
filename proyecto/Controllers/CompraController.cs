using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using proyecto.Models.DTO;
using System.Data;
using System.Globalization;
using System.Xml.Linq;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly AplicationDbContext _dbContext;
        public CompraController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet]
        [Route("Productos/{busqueda}")]
        public async Task<IActionResult> Productos(string busqueda)
        {
            List<DtoProducto> lista = new List<DtoProducto>();
            try
            {
                lista = await _dbContext.Productos
                //.Where(p => string.Concat(p.Codigo.ToLower(), p.Marca.ToLower(), p.Descripcion.ToLower()).Contains(busqueda.ToLower()))
                .Where(p => string.Concat(p.Codigo.ToLower(), p.Descripcion.ToLower()).Contains(busqueda.ToLower()))
                .Select(p => new DtoProducto()
                {
                    IdProducto = p.IdProducto,
                    Codigo = p.Codigo,
                    IdMarca = p.IdMarca,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio
                }).ToListAsync();


                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registrar([FromBody] DtoCotizacion request)
        {
            try
            {
                string numeroDocumento = "";

                XElement productos = new XElement("Productos");
                foreach (DtoProducto item in request.listaProductos)
                {
                    productos.Add(new XElement("Item",
                        new XElement("IdProducto", item.IdProducto),
                        new XElement("Cantidad", item.Cantidad),
                        new XElement("Precio", item.Precio),
                        new XElement("Total", item.Total)
                        ));
                }

                using (SqlConnection con = new SqlConnection(_dbContext.Database.GetConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCompra", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("documentoCliente", SqlDbType.VarChar, 40).Value = request.DocumentoCliente;
                    cmd.Parameters.Add("nombreCliente", SqlDbType.VarChar, 40).Value = request.NombreCliente;
                    cmd.Parameters.Add("tipoDocumento", SqlDbType.VarChar, 50).Value = request.TipoDocumento;
                    cmd.Parameters.Add("idUsuario", SqlDbType.Int).Value = request.IdUsuario;
                    cmd.Parameters.Add("subTotal", SqlDbType.Decimal).Value = request.SubTotal;
                    cmd.Parameters.Add("impuestoTotal", SqlDbType.Decimal).Value = request.Igv;
                    cmd.Parameters.Add("total", SqlDbType.Decimal).Value = request.Total;
                    cmd.Parameters.Add("productos", SqlDbType.Xml).Value = productos.ToString();
                    cmd.Parameters.Add("nroDocumento", SqlDbType.VarChar, 6).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    numeroDocumento = cmd.Parameters["nroDocumento"].Value.ToString();
                }

                return StatusCode(StatusCodes.Status200OK, new { numeroDocumento = numeroDocumento });
            }
            catch (Exception ex)
            {

                var str = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new { numeroDocumento = "" });
            }

        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            string buscarPor = HttpContext.Request.Query["buscarPor"];
            string numeroCotizacion = HttpContext.Request.Query["numeroCotizacion"];
            string fechaInicio = HttpContext.Request.Query["fechaInicio"];
            string fechaFin = HttpContext.Request.Query["fechaFin"];

            DateTime _fechainicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"));
            DateTime _fechafin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"));

            List<DtoHistorialCotizacion> lista_Cotizacion = new List<DtoHistorialCotizacion>();
            try
            {
                if (buscarPor == "fecha")
                {
                    lista_Cotizacion = await _dbContext.Cotizacion
                        .Include(u => u.Usuario)
                        .Include(d => d.DetalleCotizacion)
                        .ThenInclude(p => p.Producto)
                        .Where(v => v.FechaRegistro.Value.Date >= _fechainicio.Date && v.FechaRegistro.Value.Date <= _fechafin.Date)
                        .Select(v => new DtoHistorialCotizacion()
                        {
                            FechaRegistro = v.FechaRegistro.Value.ToString("dd/MM/yyyy"),
                            TipoDocumento = v.TipoDocumento,
                            UsuarioRegistro = v.Usuario.Nombre,
                            SubTotal = v.SubTotal.ToString(),
                            Impuesto = v.ImpuestoTotal.ToString(),
                            Total = v.Total.ToString(),
                            Detalle = v.DetalleCotizacion.Select(d => new DtoDetalleCotizacion()
                            {
                                Producto = d.Producto.Descripcion,
                                Cantidad = d.Cantidad.ToString(),
                                Precio = d.Precio.ToString(),
                                Total = d.Total.ToString()
                            }).ToList()
                        })
                        .ToListAsync();
                }
                else
                {
                    lista_Cotizacion = await _dbContext.Cotizacion
                        .Include(u => u.Usuario)
                        .Include(d => d.DetalleCotizacion)
                        .ThenInclude(p => p.Producto)
                        //.Where(v => v.NumeroDocumento == numeroCotizacion)
                        .Select(v => new DtoHistorialCotizacion()
                        {
                            FechaRegistro = v.FechaRegistro.Value.ToString("dd/MM/yyyy"),
                            //NumeroDocumento = v.NumeroDocumento,
                            TipoDocumento = v.TipoDocumento,
                            //DocumentoCliente = v.DocumentoCliente,
                            //NombreCliente = v.NombreCliente,
                            UsuarioRegistro = v.Usuario.Nombre,
                            SubTotal = v.SubTotal.ToString(),
                            Impuesto = v.ImpuestoTotal.ToString(),
                            Total = v.Total.ToString(),
                            Detalle = v.DetalleCotizacion.Select(d => new DtoDetalleCotizacion()
                            {
                                Producto = d.Producto.Descripcion,
                                Cantidad = d.Cantidad.ToString(),
                                Precio = d.Precio.ToString(),
                                Total = d.Total.ToString()
                            }).ToList()
                        }).ToListAsync();
                }


                return StatusCode(StatusCodes.Status200OK, lista_Cotizacion);
            }
            catch (Exception ex)
            {
                var str = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, lista_Cotizacion);
            }
        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte()
        {
            string fechaInicio = HttpContext.Request.Query["fechaInicio"];
            string fechaFin = HttpContext.Request.Query["fechaFin"];

            DateTime _fechainicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"));
            DateTime _fechafin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"));

            List<DtoReporteCotizacion> lista_Cotizacion = new List<DtoReporteCotizacion>();
            try
            {
                lista_Cotizacion = (from v in _dbContext.Cotizacion
                                    join d in _dbContext.DetalleCotizacion on v.IdCotizacion equals d.IdCotizacion
                                    join p in _dbContext.Productos on d.IdProducto equals p.IdProducto
                                    where v.FechaRegistro.Value.Date >= _fechainicio.Date && v.FechaRegistro.Value.Date <= _fechafin.Date
                                    select new DtoReporteCotizacion()
                                    {
                                        FechaRegistro = v.FechaRegistro.Value.ToString("dd/MM/yyyy"),
                                        //NumeroDocumento = v.NumeroDocumento,
                                        TipoDocumento = v.TipoDocumento,
                                        //DocumentoCliente = v.DocumentoCliente,
                                        //NombreCliente = v.NombreCliente,
                                        SubTotalCotizacion = v.SubTotal.ToString(),
                                        ImpuestoTotalCotizacion = v.ImpuestoTotal.ToString(),
                                        TotalCotizacion = v.Total.ToString(),
                                        Producto = p.Descripcion,
                                        Cantidad = d.Cantidad.ToString(),
                                        Precio = d.Precio.ToString(),
                                        Total = d.Total.ToString()
                                    }).ToList();



                return StatusCode(StatusCodes.Status200OK, lista_Cotizacion);
            }
            catch (Exception ex)
            {
                var str = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, lista_Cotizacion);
            }
        }
    }
}