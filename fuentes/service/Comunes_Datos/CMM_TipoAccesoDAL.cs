using Comunes_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Comunes_Datos
{
    public class CMM_TipoAccesoDAL
    {

        #region Singleton
        private static readonly CMM_TipoAccesoDAL _instancia = new CMM_TipoAccesoDAL();
        public static CMM_TipoAccesoDAL Instancia
        {
            get { return CMM_TipoAccesoDAL._instancia; }
        }
        #endregion Singleton

        public List<CMM_TipoAccesoEL> ObtenerPermisos(String Perfil)
        {
            SqlCommand cmd = null;
            List<CMM_TipoAccesoEL> cMM_TipoAccesoELs = new List<CMM_TipoAccesoEL>();
            CMM_TipoAccesoEL cMM_TipoAccesoEL = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerTipoAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@perfil", Perfil); 
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cMM_TipoAccesoEL = new CMM_TipoAccesoEL();
                    cMM_TipoAccesoEL.acceso = dr["acceso"].ToString();
                    cMM_TipoAccesoEL.codigoAcceso = dr["codigo"].ToString();
                    cMM_TipoAccesoEL.path = dr["path"].ToString();
                    cMM_TipoAccesoELs.Add(cMM_TipoAccesoEL);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return cMM_TipoAccesoELs;
        }

    }
}
