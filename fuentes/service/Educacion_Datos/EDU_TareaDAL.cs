using Comunes_Datos;
using Educacion_Entidades;
using Servicio_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Educacion_Datos
{
    public class EDU_TareaDAL
    {
        #region Singleton
        private static readonly EDU_TareaDAL _instancia = new EDU_TareaDAL();
        public static EDU_TareaDAL Instancia
        {
            get { return EDU_TareaDAL._instancia; }
        }
        #endregion Singleton

        public List<SER_TareaEL> GetTarea(String codigoClase, String periodo)
        {
            SqlCommand cmd = null;
            List<SER_TareaEL> _TareaELs = new List<SER_TareaEL>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerTareas", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_clase", codigoClase);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _TareaELs.Add(
                        new SER_TareaEL()
                        {
                            codigo = dr["codigo_tarea"].ToString(),
                            nombre = dr["nombre_tarea"].ToString(),
                            nroSemana = Int32.Parse(dr["semana"].ToString())
                        }
                 );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return _TareaELs;
        }
        public Boolean InsertTarea(EDU_TareaEL eDU_TareaEL)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_InsertarTareas", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_clase", eDU_TareaEL.codigo);
                cmd.Parameters.AddWithValue("@semana", eDU_TareaEL.semana);
                cmd.Parameters.AddWithValue("@nombre_tarea", eDU_TareaEL.nombre);                 
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    inserto = true;
                } 
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserto;
        }
    }
}
