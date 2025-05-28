using Microsoft.AspNetCore.Mvc;
using UnidadesAgua.DataAccess;
using UnidadesAgua.DataAnalisis;
using UnidadesAgua.Models;

namespace UnidadesAgua.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerrenoController : Controller
    {
        [HttpPost]
        public ActionResult Post([FromBody] AlturaTerreno terreno)
        {
            if (terreno == null )
            {
                return BadRequest("No se proporcionaron alturas válidas.");
            }
            DATerreno dA = new DATerreno();
            dA.AlmacenaTerreno(terreno);
            return Ok("Análisis de terreno completado.");
        }

        [HttpGet("{posicion}")]
        public ActionResult Get(int posicion)
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
            return Ok(terreno);
        }
    }
}
