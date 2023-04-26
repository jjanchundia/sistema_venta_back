using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using proyecto.Models.DTO;

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

        [HttpGet]
        [Route("ListaPermisos")]
        public async Task<IActionResult> ListaPermisos()
        {
            List<DtoRolPermiso> lista = new List<DtoRolPermiso>();
            try
            {
                //lista = await _dbContext.Permiso.ToListAsync();
                lista = (from p in _dbContext.Permiso
                         select new DtoRolPermiso()
                         {
                             IdRol = 0,
                             IdPermiso = p.IdPermiso,
                             IdRolPermiso = 0,
                             Descripcion = p.NombrePermiso,
                             Checked = false
                         }).ToList();

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }


        [HttpGet]
        [Route("PermisosPorId/{id:int}")]
        public async Task<IActionResult> PermisosPorId(int id)
        {
            var lista = new List<DtoRolPermiso>();
            try
            {
                lista = (from rp in _dbContext.RolPermiso
                                    join p in _dbContext.Permiso on rp.IdPermiso equals p.IdPermiso
                                    //join c in _dbContext.Cliente on v.IdCliente equals c.IdCliente
                                    where rp.IdRol == id
                                    select new DtoRolPermiso()
                                    {
                                        IdRol = rp.IdRol,
                                        IdPermiso = p.IdPermiso,
                                        IdRolPermiso = rp.IdRolPermiso,
                                        Descripcion = p.NombrePermiso,
                                        Checked = true
                                    }).ToList();


                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(Rol request)
        {
            try
            {
                await _dbContext.Rols.AddAsync(request);
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
        public async Task<IActionResult> Editar([FromBody] Rol request)
        {
            try
            {
                _dbContext.Rols.Update(request);
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
                Rol Rol = _dbContext.Rols.Find(id);
                _dbContext.Rols.Remove(Rol);
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
