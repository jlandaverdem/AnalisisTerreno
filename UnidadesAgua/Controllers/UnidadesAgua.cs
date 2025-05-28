using Microsoft.AspNetCore.Mvc;
using UnidadesAgua.DataAccess;
using UnidadesAgua.DataAnalisis;

namespace UnidadesAgua.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnidadesAgua : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {

            var analisis = new Analisis();
            analisis.EjecutaAnalisis();

            return Ok("Unidades de Agua API is running.");
        }

        [HttpGet("{posicion}")]
        public ActionResult<int> Get(int posicion)
        {
            if (posicion < 0)
            {
                return BadRequest("Posición no válida.");
            }
            DATerreno dA = new DATerreno();
            var terreno = dA.ConsultaTerreno(posicion);
            if (terreno == null)
            {
                return NotFound("Terreno no encontrado.");
            }
            var analisis = new Analisis();
            int unidadesAgua = analisis.AnalizaTerreno(terreno);
            return Ok(unidadesAgua);
        }

    }
}
