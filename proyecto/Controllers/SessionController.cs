using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using proyecto.Models.DTO;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly AplicationDbContext _dbContext;
        public SessionController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Dtosesion request)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario = _dbContext.Usuarios.Include(u => u.IdRolNavigation).Where(u => u.Correo == request.correo && u.Clave == request.clave).FirstOrDefault();

                if(usuario == null)
                    usuario = new Usuario();

                return StatusCode(StatusCodes.Status200OK, usuario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, usuario);
            }
        }
    }
}
