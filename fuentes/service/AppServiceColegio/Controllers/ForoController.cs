using System; 
using AppServiceColegio.Entidades;
using Educacion_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppServiceColegio.Controllers
{ 
    [ApiController]
    [Produces("application/json")]
    public class ForoController : ControllerBase
    {
        [HttpGet]
        [Route("api/educacion/foro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetForo(ForoRequest foroRequest)
        {
            BaseResponse response = new BaseResponse();
            if (null == foroRequest || foroRequest.codigoClase == null || foroRequest.codigoUsuario == null)
            {
                return BadRequest();
            }           
             
            return Ok(EDU_ForoBL.Instancia.GetForo(foroRequest.codigoClase, foroRequest.codigoUsuario));
        }


        [HttpGet]
        [Route("api/educacion/foro-detalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetForoDetalle(ForoRequest foroRequest)
        {
            BaseResponse response = new BaseResponse();
            if (null == foroRequest || foroRequest.codigoForo == null)
            {
                return BadRequest();
            }

            return Ok(EDU_ForoBL.Instancia.GetForoDetalle(foroRequest.codigoForo));
        }

        [HttpPost]
        [Route("api/educacion/foro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult InsertForo(ForoRequest foroRequest)
        {
            BaseResponse response = new BaseResponse();
            if (null == foroRequest || foroRequest.codigoClase == null)
            {
                return BadRequest();
            }

            Boolean estado = EDU_ForoBL.Instancia.InsertForo(foroRequest.codigoClase, foroRequest.tema, foroRequest.descripcion, foroRequest.temaPadre, foroRequest.codigoUsuario, foroRequest.codigoForo);

            if (estado)
            {
                response.estado = estado;
                response.codigo = 200;
            }
            else
            {
                response.estado = estado;
                response.codigo = 500;
            }
            return Ok(response);
        }
    }
}
