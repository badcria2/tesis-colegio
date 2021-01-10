﻿using AppServiceColegio.Entidades;
using Educacion_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceColegio.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class AsistenciaController : ControllerBase
    {
        [HttpGet]
        [Route("api/educacion/asistencia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAsistencia(AsistenciaRequest asistenciaRequest)
        {
            if (null == asistenciaRequest || asistenciaRequest.clase == null || asistenciaRequest.codigoUsuario == null || asistenciaRequest.fechaRegistro == null)
            {
                return BadRequest();
            }

            return Ok(EDU_AsistenciaBL.Instancia.GetAsistencia(
                asistenciaRequest.clase,
                asistenciaRequest.codigoUsuario,
                asistenciaRequest.fechaRegistro,
                asistenciaRequest.periodo == null ? DateTime.Now.Year.ToString() : asistenciaRequest.periodo));
        }
    }
}