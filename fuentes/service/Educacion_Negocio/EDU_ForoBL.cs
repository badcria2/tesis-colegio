using Educacion_Datos;
using Servicio_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educacion_Negocio
{
    public class EDU_ForoBL
    {
        #region Singleton
        private static readonly EDU_ForoBL _instancia = new EDU_ForoBL();
        public static EDU_ForoBL Instancia
        {
            get { return EDU_ForoBL._instancia; }
        }
        #endregion Singleton
        public List<SER_ForoEL> GetForo(String codigoClase, String codigoUsuario)
        {
            try
            {
                return EDU_ForoDAL.Instancia.GetForo(codigoClase, codigoUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<SER_ForoBaseEL> GetForoDetalle(String codigoForo)
        {
            try
            {
                return EDU_ForoDAL.Instancia.GetForoDetalle(codigoForo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertForo(String codigoClase, String tema, String descripcion, String temaPadre, String usuario, String codigoForo)
        {
            try
            {
                return EDU_ForoDAL.Instancia.InsertForo(codigoClase, tema, descripcion, temaPadre, usuario, codigoForo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
