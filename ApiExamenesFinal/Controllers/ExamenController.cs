using Microsoft.AspNetCore.Mvc;
using ApiExamenesFinal.Models;

namespace ApiExamenesFinal.Controllers
{
    [ApiController]
    [Route("examen")]
    public class ExamenController : ControllerBase
    {
        private static int nextId = 1;
        private static List<Examen> examenes = new List<Examen>();

        // GET examen/listar
        [HttpGet]
        [Route("listar")]
        public ActionResult<List<Examen>> ListarExamenes()
        {
            return examenes;
        }

        // GET examen/{id}
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Examen> ObtenerExamenPorId(string id)
        {
            var examen = examenes.Find(e => e.id == id);
            if (examen == null)
            {
                return NotFound();
            }

            return examen;
        }

        // POST examen
        [HttpPost]
        public ActionResult<Examen> InsertarExamen(Examen examen)
        {
            examen.id = (nextId++).ToString();

            examenes.Add(examen);
            return CreatedAtAction(nameof(ObtenerExamenPorId), new { id = examen.id }, examen);
        }

        // PUT examen/{id}
        [HttpPut]
        [Route("{id}")]
        public IActionResult ActualizarExamen(string id, Examen examenActualizado)
        {
            var examen = examenes.Find(e => e.id == id);
            if (examen == null)
            {
                return NotFound();
            }

            examen.Texto = examenActualizado.Texto;
            examen.Porcentaje = examenActualizado.Porcentaje;
            examen.Curso = examenActualizado.Curso;
            examen.Precio = examenActualizado.Precio;
            examen.Imagen = examenActualizado.Imagen;

            return NoContent();
        }

        // DELETE examen/{id}
        [HttpDelete]
        [Route("{id}")]
        public IActionResult EliminarExamen(string id)
        {
            var examen = examenes.Find(e => e.id == id);
            if (examen == null)
            {
                return NotFound();
            }

            examenes.Remove(examen);
            return NoContent();
        }
    }
}
