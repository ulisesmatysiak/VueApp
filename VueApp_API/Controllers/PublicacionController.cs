using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueApp_API.Models;

namespace VueApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {
        private readonly VueappDbContext _context;

        public PublicacionController(VueappDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Listar_Publicacion()
        {
            try
            {
                var publicaciones = await _context.Publicacions.ToListAsync();
                return Ok(new { mensaje = "Publicaciones: ", publicaciones });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Insertar_Publicacion([FromBody] Publicacion publicacion)
        {
            try
            {
                _context.Publicacions.Add(publicacion);
                await _context.SaveChangesAsync();

                return Ok(new { mensaje = $"Nuevo registro con id: {publicacion.IdPublicacion} insertado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Editar_Publicacion(int id, [FromBody] Publicacion publicacion)
        {
            Publicacion edit = _context.Publicacions.Find(id);
            if (edit == null)
                return BadRequest("Publicacion no encontrada");

            try
            {
                edit.TipoPropiedad = publicacion.TipoPropiedad;
                edit.TipoOperacion = publicacion.TipoOperacion;
                edit.Descripcion = publicacion.Descripcion;
                edit.Ambientes = publicacion.Ambientes;
                edit.MetrosCuadrados = publicacion.MetrosCuadrados;
                edit.Antiguedad = publicacion.Antiguedad;
                edit.CoordenadasUbicacion = publicacion.CoordenadasUbicacion;
                edit.Imagenes = publicacion.Imagenes;
                await _context.SaveChangesAsync();
                return Ok(new { mensaje = $"Registro con id: {edit.IdPublicacion} editado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar_Publicacion(int id)
        {
            Publicacion publicacion = _context.Publicacions.Find(id);
            if (publicacion == null)
                return BadRequest("Publicacion no encontrada");

            try
            {
                _context.Publicacions.Remove(publicacion);
                await _context.SaveChangesAsync();
                return Ok(new { mensaje = $"Registro con id: {publicacion.IdPublicacion} eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
    }
}
