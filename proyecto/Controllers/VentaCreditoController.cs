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
    public class VentaCreditoController : ControllerBase
    {
        private readonly AplicationDbContext _dbContext;
        public VentaCreditoController(AplicationDbContext dbContext)
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
                .Where(p => string.Concat(p.Codigo.ToLower(), p.Descripcion.ToLower()).Contains(busqueda.ToLower()))
                .Select(p => new DtoProducto()
                {
                    IdProducto = p.IdProducto,
                    Codigo = p.Codigo,
                    IdMarca = p.IdMarca,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    Stock = p.Stock
                }).ToListAsync();


                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpGet]
        [Route("Clientes/{busqueda}")]
        public async Task<IActionResult> Clientes(string busqueda)
        {
            List<DtoCliente> lista = new List<DtoCliente>();
            try
            {
                lista = await _dbContext.Cliente
                .Where(p => string.Concat(p.Cedula, p.Nombres.ToLower(), p.Apellidos.ToLower()).Contains(busqueda.ToLower()))
                .Select(p => new DtoCliente()
                {
                    IdCliente = p.IdCliente,
                    Cedula = p.Cedula,
                    Nombres = p.Nombres,
                    Apellidos = p.Apellidos
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
        public IActionResult Registrar([FromBody] DtoVenta request)
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
                    SqlCommand cmd = new SqlCommand("sp_RegistrarVentaCredito", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("cuotaInicial", SqlDbType.Decimal).Value = request.CuotaInicial;
                    cmd.Parameters.Add("cantidadMeses", SqlDbType.Int).Value = request.CantidadMeses;
                    cmd.Parameters.Add("cuotaMensual", SqlDbType.Decimal).Value = request.CuotaMensual;
                    cmd.Parameters.Add("tipoDocumento", SqlDbType.VarChar, 50).Value = request.tipoDocumento;
                    cmd.Parameters.Add("idUsuario", SqlDbType.Int).Value = request.idUsuario;
                    cmd.Parameters.Add("idCliente", SqlDbType.Int).Value = request.IdCliente;
                    cmd.Parameters.Add("subTotal", SqlDbType.Decimal).Value = request.subTotal;
                    cmd.Parameters.Add("impuestoTotal", SqlDbType.Decimal).Value = request.igv;
                    cmd.Parameters.Add("total", SqlDbType.Decimal).Value = request.total;
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
            string numeroVenta = HttpContext.Request.Query["numeroVenta"];
            string fechaInicio = HttpContext.Request.Query["fechaInicio"];
            string fechaFin = HttpContext.Request.Query["fechaFin"];

            DateTime _fechainicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"));
            DateTime _fechafin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"));

            List<DtoHistorialVenta> lista_venta = new List<DtoHistorialVenta>();
            try
            {
                if (buscarPor == "fecha")
                {
                    lista_venta = await _dbContext.Venta
                        .Include(e => e.Empresa)
                        .Include(u => u.IdUsuarioNavigation)
                        .Include(c => c.Cliente)
                        .Include(d => d.DetalleVenta)                        
                        .ThenInclude(p => p.IdProductoNavigation)
                        .Where(v => v.FechaRegistro.Value.Date >= _fechainicio.Date && v.FechaRegistro.Value.Date <= _fechafin.Date)
                        .Select(v => new DtoHistorialVenta()
                        {
                            FechaRegistro = v.FechaRegistro.Value.ToString("dd/MM/yyyy"),
                            NumeroDocumento = v.NumeroDocumento,
                            TipoDocumento = v.TipoDocumento,
                            UsuarioRegistro = v.IdUsuarioNavigation.Nombre,
                            NombreCliente = v.Cliente.Nombres + " " + v.Cliente.Apellidos,
                            DocumentoCliente = v.Cliente.Cedula,
                            SubTotal = v.SubTotal.ToString(),
                            Impuesto = v.ImpuestoTotal.ToString(),
                            Total = v.Total.ToString(),
                            Detalle = v.DetalleVenta.Select(d => new DtoDetalleVenta()
                            {
                                Producto = d.IdProductoNavigation.Descripcion,
                                Cantidad = d.Cantidad.ToString(),
                                Precio = d.Precio.ToString(),
                                Total = d.Total.ToString()
                            }).ToList()
                        })
                        .ToListAsync();
                }
                else
                {
                    lista_venta = await _dbContext.Venta
                        .Include(u => u.IdUsuarioNavigation)
                        .Include(d => d.DetalleVenta)
                        .ThenInclude(p => p.IdProductoNavigation)
                        .Where(v => v.NumeroDocumento == numeroVenta)
                        .Select(v => new DtoHistorialVenta()
                        {
                            FechaRegistro = v.FechaRegistro.Value.ToString("dd/MM/yyyy"),
                            NumeroDocumento = v.NumeroDocumento,
                            TipoDocumento = v.TipoDocumento,
                            UsuarioRegistro = v.IdUsuarioNavigation.Nombre,
                            NombreCliente = v.Cliente.Nombres + " " + v.Cliente.Apellidos,
                            DocumentoCliente = v.Cliente.Cedula,
                            SubTotal = v.SubTotal.ToString(),
                            Impuesto = v.ImpuestoTotal.ToString(),
                            Total = v.Total.ToString(),
                            Detalle = v.DetalleVenta.Select(d => new DtoDetalleVenta()
                            {
                                Producto = d.IdProductoNavigation.Descripcion,
                                Cantidad = d.Cantidad.ToString(),
                                Precio = d.Precio.ToString(),
                                Total = d.Total.ToString()
                            }).ToList()
                        }).ToListAsync();
                }


                return StatusCode(StatusCodes.Status200OK, lista_venta);
            }
            catch (Exception ex)
            {
                var str = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, lista_venta);
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

            List<DtoReporteVenta> lista_venta = new List<DtoReporteVenta>();
            try
            {
                lista_venta = (from v in _dbContext.Venta
                               join d in _dbContext.DetalleVenta on v.IdVenta equals d.IdVenta
                               join p in _dbContext.Productos on d.IdProducto equals p.IdProducto
                               join c in _dbContext.Cliente on v.IdCliente equals c.IdCliente
                               where v.FechaRegistro.Value.Date >= _fechainicio.Date && v.FechaRegistro.Value.Date <= _fechafin.Date
                               select new DtoReporteVenta()
                               {
                                   FechaRegistro = v.FechaRegistro.Value.ToString("dd/MM/yyyy"),
                                   NumeroDocumento = v.NumeroDocumento,
                                   TipoDocumento = v.TipoDocumento,
                                   DocumentoCliente = c.Cedula,
                                   NombreCliente = $"{c.Nombres} {c.Apellidos}",//c.Nombres + ""
                                   SubTotalVenta = v.SubTotal.ToString(),
                                   ImpuestoTotalVenta = v.ImpuestoTotal.ToString(),
                                   TotalVenta = v.Total.ToString(),
                                   Producto = p.Descripcion,
                                   Cantidad = d.Cantidad.ToString(),
                                   Precio = d.Precio.ToString(),
                                   Total = d.Total.ToString()
                               }).ToList();



                return StatusCode(StatusCodes.Status200OK, lista_venta);
            }
            catch (Exception ex)
            {
                var str = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, lista_venta);
            }
        }
    }
}
