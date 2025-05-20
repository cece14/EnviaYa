using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.InterfacesCasosDeUso;
using DTO;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnviosApiController : ControllerBase
    {
       public IObtenerEnvioPorTracking cuObtenerNroDeTracking;

        public EnviosApiController(IObtenerEnvioPorTracking cuObtenerPorTracking)
        {
            cuObtenerNroDeTracking = cuObtenerPorTracking;
        }

        // GET: api/enviosapi/{nroTracking}

        [HttpGet("{nroTracking}")]
        public IActionResult ObtenerPorTracking(string nroTracking)
        {
            var envio = cuObtenerNroDeTracking.ObtenerPorTracking(nroTracking);

            if (envio == null)
                return NotFound(new { mensaje = "No se encontró un envío con ese número de tracking." });

            return Ok(envio); 
        }
    }
}