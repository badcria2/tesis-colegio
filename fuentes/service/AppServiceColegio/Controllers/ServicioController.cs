using System;
using AppServiceColegio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppServiceColegio.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ServicioController : ControllerBase
    {
        [HttpGet]
        [Route("api/servicio/obtener-cursos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCursos(CursosRequest cursosRequest)
        {
            if (null == cursosRequest || cursosRequest.usuario == null)
            {
                return BadRequest();
            }

            return Ok(Servicio_Negocio.SER_CursoBL.Instancia.GetCurso(cursosRequest.usuario, cursosRequest.periodo == null ? DateTime.Now.Year.ToString() : cursosRequest.periodo));
        }

        [HttpGet]
        [Route("api/servicio/curso-detalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDetCurso(MaterialRequest materialRequest)
        {
            if (null == materialRequest || materialRequest.codigoClase == null)
            {
                return BadRequest();
            }

            return Ok(Servicio_Negocio.SER_CursoBL.Instancia.GetDetCurso(materialRequest.codigoClase, materialRequest.periodo == null ? DateTime.Now.Year.ToString() : materialRequest.periodo));
        }
    }
}
