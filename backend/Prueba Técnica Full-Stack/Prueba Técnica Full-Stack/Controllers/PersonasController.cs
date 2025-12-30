using Microsoft.AspNetCore.Mvc;
using Prueba_Técnica.Data;
using Prueba_Técnica.Models;

namespace Prueba_Técnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaRepository _repo = new();

        [HttpGet]
        public ActionResult<List<Persona>> Get() => Ok(_repo.Listar());

        [HttpGet("{id}")]
        public ActionResult<Persona> GetById(int id)
        {
            var persona = _repo.ObtenerPorId(id);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public ActionResult Crear(Persona persona)
        {
            _repo.Crear(persona);
            return Ok(persona);
        }

        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, Persona persona)
        {
            var ok = _repo.Actualizar(id, persona);
            if (!ok) return NotFound();
            return Ok(persona);
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            var ok = _repo.Eliminar(id);
            if (!ok) return NotFound();
            return Ok();
        }
    }
}

