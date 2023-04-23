using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AplicationDbContext _dbContext;
        public DashboardController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet]
        [Route("Usuarios")]
        public IActionResult Usuarios()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _dbContext.Usuarios.Select(x => x.IdUsuario).Count());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Ventas")]
        public IActionResult Ventas()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _dbContext.Venta.Select(x => x.IdVenta).Count());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Productos")]
        public IActionResult Productos()
        {
            try
            {
                var productos = _dbContext.Productos.Select(x => x.IdProducto).Count();
                return StatusCode(StatusCodes.Status200OK, productos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Compras")]
        public IActionResult Compras()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _dbContext.Compra.Select(x => x.IdCompra).Count());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
