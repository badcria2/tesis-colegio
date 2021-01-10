using Educacion_Datos;
using Educacion_Entidades;
using Persona_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educacion_Negocio
{
    public class EDU_AsistenciaBL
    {

        #region Singleton
        private static readonly EDU_AsistenciaBL _instancia = new EDU_AsistenciaBL();
        public static EDU_AsistenciaBL Instancia
        {
            get { return EDU_AsistenciaBL._instancia; }
        }
        #endregion Singleton
        public List<PER_AsistenteEL> GetAsistencia(String codigoClase, String codigoUsuario, String fechaRegistro, String periodo)
        {
            try
            {
                return EDU_AsistenciaDAL.Instancia.GetAsistencia(codigoClase, codigoUsuario, fechaRegistro, periodo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
