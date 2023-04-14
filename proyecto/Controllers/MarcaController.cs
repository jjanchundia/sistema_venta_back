using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using proyecto.Models.DTO;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly AplicationDbContext _dbContext;
        public MarcaController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Marca> lista = new List<Marca>();
            try
            {
                lista = await _dbContext.Marca.OrderByDescending(c => c.IdMarca).ToListAsync();
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(DtoMarca request)
        {
            try
            {
                await _dbContext.AddAsync(new Marca
                {
                    NombreMarca = request.NombreMarca
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
        public async Task<IActionResult> Editar([FromBody] DtoMarca request)
        {
            try
            {
                Marca DtoMarcaM = _dbContext.Marca.Find(request.IdMarca);
                DtoMarcaM.NombreMarca = request.NombreMarca;
                _dbContext.Marca.Update(DtoMarcaM);
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
                Marca DtoMarca = _dbContext.Marca.Find(id);
                _dbContext.Marca.Remove(DtoMarca);
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
