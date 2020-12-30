using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServiceColegio.Entidades;
using Educacion_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppServiceColegio.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class TareaController : ControllerBase
    {
        [HttpPost]
        [Route("api/educacion/documento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult InserTarea(DocumentoRequest materialRequest)
        {
            BaseResponse response = new BaseResponse();
            if (null == materialRequest || materialRequest.codigoClase == null)
            {
                return BadRequest();
            }
            Boolean estado = EDU_TareaBL.Instancia.InsertTarea(materialRequest.codigoClase, materialRequest.nombre, materialRequest.semana, materialRequest.origen, materialRequest.usuario);
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

        [HttpPost]
        [Route("api/educacion/delete-documento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteDocument(DocumentRequestDelete documentRequestDelete)
        {
            BaseResponse response = new BaseResponse();
            if (null == documentRequestDelete || documentRequestDelete.tipo == null)
            {
                return BadRequest();
            }
            Boolean estado = EDU_TareaBL.Instancia.DeleteDocumento(documentRequestDelete.codigo, documentRequestDelete.tipo);
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
