using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using proyecto.Models.DTO;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AplicationDbContext _dbContext;
        public UsuarioController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                lista = await _dbContext.Usuarios.Include(r => r.IdRolNavigation).OrderByDescending(c => c.IdUsuario).ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpGet]
        [Route("UsuarioPorId/{id:int}")]
        public async Task<IActionResult> UsuarioPorId(int id)
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                lista = await _dbContext.Usuarios.Where(x=>x.IdUsuario == id).Include(r => r.IdRolNavigation).OrderByDescending(c => c.IdUsuario).ToListAsync();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Usuario request)
        {
            try
            {
                await _dbContext.Usuarios.AddAsync(request);
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
        public async Task<IActionResult> Editar(DtoUsuario request)
        {
            try
            {
                Usuario usuarioM = _dbContext.Usuarios.Find(request.IdUsuario);
                usuarioM.Nombre = request.Nombre;
                usuarioM.Correo = request.Correo;
                usuarioM.Telefono = request.Telefono;
                usuarioM.Clave = request.Clave;
                _dbContext.Usuarios.Update(usuarioM);
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
                Usuario usuario = _dbContext.Usuarios.Find(id);
                _dbContext.Usuarios.Remove(usuario);
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
