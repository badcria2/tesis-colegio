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
        public IActionResult autenticacion(CursosRequest cursosRequest)
        {
            if (null == cursosRequest || cursosRequest.usuario == null)
            {
                return BadRequest();
            }

            return Ok(Servicio_Negocio.SER_CursoBL.Instancia.DevolverCursos(cursosRequest.usuario, cursosRequest.periodo == null ? DateTime.Now.Year.ToString() : cursosRequest.periodo));
        }
    }
}
