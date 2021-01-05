using Comunes_Datos;
using Educacion_Negocio;
using Servicio_Datos;
using Servicio_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio_Negocio
{
    public class SER_CursoBL
    {
        #region Singleton
        private static readonly SER_CursoBL _instancia = new SER_CursoBL();
        public static SER_CursoBL Instancia
        {
            get { return SER_CursoBL._instancia; }
        }
        #endregion Singleton
        public List<SER_CursoEL> GetCurso(String usuario, String periodo, String perfil, String grado, String seccion)
        {
            try
            {
                var _CursoELs = SER_CursoDAL.Instancia.GetCurso(usuario, periodo, perfil, grado, seccion);
                return _CursoELs;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public SER_DetCursoEL GetDetCurso(String codigoClase, String periodo, String codigoUsuario)
        {
            try
            {
                var _DetCursoEL = SER_CursoDAL.Instancia.GetDetCurso(codigoClase, periodo);
                if (null != _DetCursoEL.codigo)
                {
                    var periodos = CMM_TipoAccesoDAL.Instancia.ObtenerRangoMeses(codigoClase);
                    _DetCursoEL.periodos = periodos;
                    var tareas = EDU_TareaBL.Instancia.GetTareas(codigoClase, periodo, codigoUsuario);
                    foreach (var tarea in tareas)
                    {
                        _DetCursoEL.material.Find(p => p.nroSemana == tarea.nroSemana).tarea = tarea;
                    }
                    return _DetCursoEL;
                }
                else return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
