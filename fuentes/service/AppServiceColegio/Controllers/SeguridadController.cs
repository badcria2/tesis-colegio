using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServiceColegio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppServiceColegio.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class SeguridadController : Controller
    {

        [HttpPost]
        [Route("api/seguridad/autenticacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult autenticacion(AutenticacionRequest autenticacionRequest)
        {
            if (null == autenticacionRequest|| autenticacionRequest.Password ==null || autenticacionRequest.Usuario == null)
            {
                return BadRequest();
            }                
            return Ok(Seguridad_Negocio.SEG_UsuarioBL.Instancia.DevolverUsuario(autenticacionRequest.Usuario, autenticacionRequest.Password));
        }
    }
}
