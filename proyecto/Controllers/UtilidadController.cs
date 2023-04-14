using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using proyecto.Models.DTO;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilidadController : ControllerBase
    {

        private readonly AplicationDbContext _dbContext;
        public UtilidadController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
        [Route("Dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            DtoDashboard config = new DtoDashboard();

            DateTime fecha = DateTime.Now;
            DateTime fecha2 = DateTime.Now;
            fecha = fecha.AddDays(-30);
            fecha2 = fecha2.AddDays(-7);
            try
            {
                config.TotalVentas = _dbContext.Venta.Where(v => v.FechaRegistro >= fecha).Count().ToString();
                config.TotalIngresos = _dbContext.Venta.Where(v => v.FechaRegistro >= fecha).Sum(v => v.Total).ToString();
                config.TotalProductos = _dbContext.Productos.Count().ToString();
                config.TotalCategorias = _dbContext.Categoria.Count().ToString();


                config.ProductosVendidos = (from p in _dbContext.Productos
                           join d in _dbContext.DetalleVenta on p.IdProducto equals d.IdProducto
                           group p by p.Descripcion into g
                           orderby g.Count() ascending
                           select new DtoProductoVendidos { Producto = g.Key, Total = g.Count().ToString()}).Take(4).ToList();

                config.VentasporDias = (from v in _dbContext.Venta
                            where v.FechaRegistro.Value.Date >= fecha2.Date
                            group v by v.FechaRegistro.Value.Date into g
                            orderby g.Key ascending
                            select new DtoVentasDias { Fecha = g.Key.ToString("dd/MM/yyyy"), Total = g.Count().ToString() }).ToList();

                return StatusCode(StatusCodes.Status200OK, config);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, config);
            }
        }

    }
}
