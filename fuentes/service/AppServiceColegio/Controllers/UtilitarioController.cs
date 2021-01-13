using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServiceColegio.Entidades;
using Comunes_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppServiceColegio.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class UtilitarioController : ControllerBase
    {
        [HttpGet]
        [Route("api/utilitario/grado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCursos(ComboRequest request)
        {
            if (null == request || request.codigoUsuario == null)
            {
                return BadRequest();
            }
            return Ok(CMM_TipoAccesoBL.Instancia.ObtenerGrados(request.codigoUsuario, request.perfil));
        }

        [HttpGet]
        [Route("api/utilitario/seccion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSeccion(ComboRequest request)
        {
            if (null == request || request.codigoUsuario == null)
            {
                return BadRequest();
            }
            return Ok(CMM_TipoAccesoBL.Instancia.ObtenerSeccion(request.codigoUsuario, request.codigo, request.perfil));
        }
    }
}
