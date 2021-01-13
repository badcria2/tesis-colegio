using Comunes_Datos;
using Comunes_Entidades;
using System;
using System.Collections.Generic;

namespace Comunes_Negocio
{
    public class CMM_TipoAccesoBL
    {
        #region Singleton
        private static readonly CMM_TipoAccesoBL _instancia = new CMM_TipoAccesoBL();
        public static CMM_TipoAccesoBL Instancia
        {
            get { return CMM_TipoAccesoBL._instancia; }
        }
        #endregion Singleton
        public List<CMM_TipoAccesoEL> ObtenerPermisos(String Perfil)
        {
            try
            {
                return CMM_TipoAccesoDAL.Instancia.ObtenerPermisos(Perfil);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CMM_PeriodoEL> ObtenerRangoMeses(String copdigoClase)
        {
            try
            {
                return CMM_TipoAccesoDAL.Instancia.ObtenerRangoMeses(copdigoClase);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CMM_ComboEL> ObtenerGrados(String codigoUsuario, String perfil)
        {
            try
            {
                return CMM_TipoAccesoDAL.Instancia.ObtenerGrados(codigoUsuario, perfil);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CMM_ComboEL> ObtenerSeccion(String copdigoClase, String grado, String perfil)
        {
            try
            {
                return CMM_TipoAccesoDAL.Instancia.ObtenerSeccion(copdigoClase, grado, perfil);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
