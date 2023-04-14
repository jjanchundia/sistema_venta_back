using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly AplicationDbContext _dbContext;
        public RolController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Rol> lista = new List<Rol>();
            try
            {
                lista = await _dbContext.Rols.ToListAsync();
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

    }
}
