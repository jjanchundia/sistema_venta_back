using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AplicationDbContext _dbContext;
        public CategoriaController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                lista = await _dbContext.Categoria.OrderByDescending(c => c.IdCategoria).ToListAsync();
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(Categoria request) {
            try
            {
                await _dbContext.Categoria.AddAsync(request);
                await _dbContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Categoria request) {
            try
            {
                _dbContext.Categoria.Update(request);
                await _dbContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id) {
            try
            {
                Categoria categoria = _dbContext.Categoria.Find(id);
                _dbContext.Categoria.Remove(categoria);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
