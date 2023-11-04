using api_parqueosHeredianos.Models;
using api_parqueosHeredianos.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_parqueosHeredianos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiqueteController : ControllerBase
    {
        private readonly TiqueteService _service;

        public TiqueteController(TiqueteService service)
        {
            _service = service;

            Tiquete ti = new Tiquete();
            ti.id = 1;
            ti.placaVehiculo = "ASD-452";
            ti.horaIngreso = "10:00";
            ti.horaSalida = "12:00";
            ti.tarifaHora = 100;
            ti.fechaUso = "20/12/2022";
            ti.horasEstacionado = 2;
            ti.idParqueo = 1;


            if (_service.Listar().Count() == 0)
            {
                _service.Agregar(ti);
            }
        }

        // GET: api/<TiqueteController>
        [HttpGet]
        public List<Tiquete> Listar()
        {
            List<Tiquete> lista = _service.Listar();
            return lista;
        }

        // GET api/<TiqueteController>/5
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            Tiquete entidad = _service.BuscarElementoEspecifico(id);
            if (entidad == null)
            {
                return NotFound("El ID buscado no se encontró.");
            }
            return Ok(entidad);
        }

        // POST api/<TiqueteController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Tiquete entidad)
        {
            _service.Agregar(entidad);
            return Ok(entidad);
        }

        // PUT api/<TiqueteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Tiquete item)
        {
            bool exito = _service.Editar(id, item);

            if (!exito)
            {
                return NotFound("El ID a editar no se encontró.");
            }

            return Ok(item);
        }

        // DELETE api/<TiqueteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Verifica si el recurso existe.
            var entidad = _service.BuscarElementoEspecifico(id);
            if (entidad == null)
            {
                // El recurso no se encontró, devolver 404 (Not Found).
                return NotFound();
            }

            // Realiza la eliminación del recurso.
            bool exito = _service.Delete(id);

            if (exito)
            {
                // La eliminación se realizó con éxito, devolver 204 (No Content).
                return NoContent();
            }

            // Si no se realizó la eliminación (por alguna razón), puedes devolver un error 500 (Internal Server Error) u otro código de error adecuado.
            return StatusCode(500, "Error al eliminar el recurso.");
        }
    }
}
