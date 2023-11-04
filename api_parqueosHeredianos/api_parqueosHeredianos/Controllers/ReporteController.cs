using api_parqueosHeredianos.Models;
using api_parqueosHeredianos.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_parqueosHeredianos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly ReporteService _service;
        private readonly ParqueoService _serviceP;

        public ReporteController(ReporteService reporteService, ParqueoService serviceP)
        {
            _service = reporteService;
            _serviceP = serviceP;

            Reporte r = new Reporte();
            List<Parqueo> lt = _serviceP.Listar();
            r.id = 100;
            r.listaParqueos = lt;

            if (_service.Listar().Count() == 0)
            {
                _service.Agregar(r);
            }
        }

        // GET: api/<ReporteController>
        [HttpGet]
        public List<Reporte> Listar()
        {
            List<Reporte> lista = _service.Listar();
            return lista;
        }

        // GET api/<ReporteController>/5
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            Reporte entidad = _service.BuscarElementoEspecifico(id);
            if (entidad == null)
            {
                return NotFound("El ID buscado no se encontró.");
            }
            return Ok(entidad);
        }

        // POST api/<ReporteController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Reporte entidad)
        {
            List<Parqueo> lt = _serviceP.Listar();
            entidad.listaParqueos = lt;

            _service.Agregar(entidad);
            return Ok(entidad);
        }

        // PUT api/<ReporteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Reporte item)
        {
            bool exito = _service.Editar(id, item);

            if (!exito)
            {
                return NotFound("El ID a editar no se encontró.");
            }

            return Ok(item);
        }

        // DELETE api/<ReporteController>/5
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
