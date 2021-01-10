using Educacion_Datos;
using Educacion_Entidades;
using Persona_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educacion_Negocio
{
    public class EDU_NotasBL
    {
        #region Singleton
        private static readonly EDU_NotasBL _instancia = new EDU_NotasBL();
        public static EDU_NotasBL Instancia
        {
            get { return EDU_NotasBL._instancia; }
        }
        #endregion Singleton
        public List<EDU_CursoEL> GetNotas(String periodo, String codigoUsuario)
        {
            try
            {
                return EDU_NotasDAL.Instancia.GetNotas(periodo, codigoUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PER_AlumnoEL> GetNotasDocente(String periodo, String codigoClase, String codigoDocente)
        {
            try
            {
                return EDU_NotasDAL.Instancia.GetNotasDocente(periodo, codigoClase, codigoDocente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean RegisterNotas(String nota, String clase, String tipo)
        {
            try
            {
                return EDU_NotasDAL.Instancia.RegisterNotas(nota, clase, tipo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
