using api_parqueosHeredianos.Models;
using api_parqueosHeredianos.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_parqueosHeredianos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoSController : ControllerBase
    {
        private readonly EmpleadoService _service;

        public EmpleadoSController(EmpleadoService service)
        {
            _service = service;

            Empleado e = new Empleado();
            e.id = 1;
            e.fechaIngreso = "2023-12-12";
            e.nombre = "Pablo";
            e.primerApellido = "Fernadez";
            e.segundoApellido = "Segura";
            e.fechaNacimiento = "2000/02/02";
            e.cedula = "02-679-282";
            e.direccion = "Las letras, a , a , a";
            e.email = "e@gmail.com";
            e.telefono = "8899-9988";
            e.nombrePersonaContacto = "Maria";
            e.telefonoPersonaContacto = "7788-8899";
            e.idParqueo = 1;

            if (_service.Listar().Count() == 0)
            {
                _service.Agregar(e);
            }

        }


        // GET: api/<ParqueoController>
        [HttpGet]
        public List<Empleado> Listar()
        {
            List<Empleado> lista = _service.Listar();
            return lista;
        }

        // GET api/<ParqueoController>/5
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            Empleado entidad = _service.BuscarElementoEspecifico(id);
            if (entidad == null)
            {
                return NotFound("El ID buscado no se encontró.");
            }
            return Ok(entidad);
        }

        // POST api/<ParqueoController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Empleado entidad)
        {
            _service.Agregar(entidad);
            return Ok(entidad);
        }

        // PUT api/<ParqueoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Empleado item)
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
