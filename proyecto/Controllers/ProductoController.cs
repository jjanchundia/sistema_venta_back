using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using proyecto.Models.DTO;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AplicationDbContext _dbContext;
        public ProductoController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                lista = await _dbContext.Productos.Include(c => c.IdCategoriaNavigation)
                    .Include(x => x.IdMarcaNavigation).OrderByDescending(c => c.IdProducto)
                    .ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(DtoProducto request)
        {
            try
            {
                await _dbContext.AddAsync(new Producto
                {
                    Codigo = request.Codigo,
                    Descripcion = request.Descripcion,
                    IdCategoria = request.IdCategoria,
                    IdMarca = request.IdMarca,
                    Stock = request.Stock,
                    Precio = request.Precio,
                    EsActivo = request.EsActivo,
                    FechaRegistro = DateTime.Now
                });
                await _dbContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] DtoProducto request)
        {
            try
            {
                Producto DtoProductoM = _dbContext.Productos.Find(request.IdProducto);
                DtoProductoM.Codigo = request.Codigo;
                DtoProductoM.Descripcion = request.Descripcion;
                DtoProductoM.IdCategoria = request.IdCategoria;
                DtoProductoM.IdMarca = request.IdMarca;
                DtoProductoM.Stock = request.Stock;
                DtoProductoM.Precio = request.Precio;
                DtoProductoM.EsActivo = request.EsActivo;
                DtoProductoM.FechaRegistro = DateTime.Now;
                await _dbContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                Producto usuario = _dbContext.Productos.Find(id);
                _dbContext.Productos.Remove(usuario);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
