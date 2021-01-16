using System;
using System.Collections.Generic;
using AppServiceColegio.Entidades;
using Educacion_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio_Negocio;

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
            if (null == cursosRequest || cursosRequest.codigoUsuario == null)
            {
                return BadRequest();
            }

            var grado = String.IsNullOrEmpty(cursosRequest.grado) ? "Todos" : cursosRequest.grado;
            var seccion = String.IsNullOrEmpty(cursosRequest.seccion) ? "Todos" : cursosRequest.seccion;
            return Ok(Servicio_Negocio.SER_CursoBL.Instancia.GetCurso(cursosRequest.codigoUsuario, cursosRequest.periodo == null ? DateTime.Now.Year.ToString() : cursosRequest.periodo, cursosRequest.perfil, grado, seccion));
        }

        [HttpGet]
        [Route("api/servicio/curso-detalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDetCurso(MaterialRequest materialRequest)
        {
            if (null == materialRequest || materialRequest.clase == null)
            {
                return BadRequest();
            }

            return Ok(Servicio_Negocio.SER_CursoBL.Instancia.GetDetCurso(
                materialRequest.clase,
                materialRequest.periodo == null ? DateTime.Now.Year.ToString() : materialRequest.periodo,
                materialRequest.codigoUsuario));
        }


        [HttpPost]
        [Route("api/servicio/curso-actualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateClase(ClaseRequest cursosRequest)
        {
            if (null == cursosRequest)
            {
                return BadRequest();
            }

            var response = Servicio_Negocio.SER_CursoBL.Instancia.UpdateClase(
                cursosRequest.codigo,
                cursosRequest.periodo == null ? DateTime.Now.Year.ToString() : cursosRequest.periodo,
                cursosRequest.fechaFin, cursosRequest.fechaInicio, cursosRequest.enlace, cursosRequest.mes, cursosRequest.semana);
            if (response)
                return Ok(new BaseResponse() { codigo = 200, estado = true });
            else return StatusCode(500);
        }

        //public Boolean (String codigoClase, String periodo, String fechaFin, String fechaInicio, String enlace)

        [HttpGet]
        [Route("api/servicio/notas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetNotas(NotasRequest notasRequest)
        {
            if (null == notasRequest || notasRequest.codigoUsuario == null)
            {
                return BadRequest();
            }

            return Ok(EDU_NotasBL.Instancia.GetNotas(
                notasRequest.periodo == null || notasRequest.periodo.Equals("") ? DateTime.Now.Year.ToString() : notasRequest.periodo,
                notasRequest.codigoUsuario
                ));
        }
        [HttpGet]
        [Route("api/servicio/notas-docente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetNotasDocente(NotasRequest notasRequest)
        {
            if (null == notasRequest || notasRequest.codigoUsuario == null || notasRequest.clase == null)
            {
                return BadRequest();
            }

            return Ok(EDU_NotasBL.Instancia.GetNotasDocente(
                notasRequest.periodo == null || notasRequest.periodo.Equals("") ? DateTime.Now.Year.ToString() : notasRequest.periodo,
                notasRequest.clase,
                notasRequest.codigoUsuario
                ));
        }

        [HttpGet]
        [Route("api/servicio/registrar-notas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RegisterNotas(List<NotasRequest> notasRequest)
        {
            if (null == notasRequest || notasRequest.Count == 0)
            {
                return BadRequest();
            }
            int eliminar = 0;
            int count = 0;
            for (int i = 0; i < notasRequest.Count; i++)
            {
                if ((i) % 3 == 0)
                    eliminar = 1;
                else eliminar = 0;
                if (EDU_NotasBL.Instancia.RegisterNotas(notasRequest[i].nota, notasRequest[i].clase, notasRequest[i].tipo, eliminar))
                {
                    count++;
                }

            }

            if (count == notasRequest.Count)
                return Ok(new BaseResponse() { codigo = 200, estado = true });
            else return StatusCode(500);
        }

        [HttpGet]
        [Route("api/servicio/avisos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAvisos()
        {
            return Ok(SER_AvisoBL.Instancia.GetAvisos());
        }

        [HttpPost]
        [Route("api/servicio/avisos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult InsertAvisos(AvisoRequest avisoRequest)
        {
            BaseResponse response = new BaseResponse();
            Boolean estado = SER_AvisoBL.Instancia.InsertAviso(avisoRequest.titulo,
                    avisoRequest.contenido, avisoRequest.imagen, avisoRequest.codigoAviso,
                    avisoRequest.fechaInicio, avisoRequest.fechaFin, avisoRequest.usuario);
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
