using api_parqueosHeredianos.Models;
using api_parqueosHeredianos.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_parqueosHeredianos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParqueoController : ControllerBase
    {
        private readonly ParqueoService _service;
        public ParqueoController(ParqueoService service)
        {
            _service = service;
            
            Parqueo p = new Parqueo();

            p.id = 1;
            p.total = 0;
            p.horaCierre = "22:00";
            p.horaApertura = "10:00";
            p.cantMaxVehiculos = 10;
            p.nombre = "Homer";

            if (_service.Listar().Count() == 0)
            {
                _service.Agregar(p);
            }
            
        }
        // GET: api/<ParqueoController>
        [HttpGet]
        public List<Parqueo> Listar()
        {
            List<Parqueo> lista = _service.Listar();
            return lista;
        }

        // GET api/<ParqueoController>/5
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            Parqueo entidad = _service.BuscarElementoEspecifico(id);
            if (entidad == null)
            {
                return NotFound("El ID buscado no se encontró.");
            }
            return Ok(entidad);
        }

        // POST api/<ParqueoController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Parqueo entidad)
        {

            _service.Agregar(entidad);
            return Ok(entidad);
        }

        // PUT api/<ParqueoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Parqueo item)
        {
            bool exito = _service.Editar(id, item);

            if (!exito)
            {
                return NotFound("El ID a editar no se encontró.");
            }

            return Ok(item);
        }

        // DELETE api/<ParqueoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Verifica si el recurso existe.
            var entidad = _service.BuscarElementoEspecifico(id);
            if (entidad == null)
            {
                return NotFound("El ID a eliminar no se encontró.");
            }

            // Realiza la eliminación del recurso.
            bool exito = _service.Delete(id);

            if (exito)
            {
                // La eliminación se realizó con éxito, devolver 204 (No Content).
                return NoContent();
            } 
            return StatusCode(500, "Error al eliminar el recurso.");
        }
    }
}
