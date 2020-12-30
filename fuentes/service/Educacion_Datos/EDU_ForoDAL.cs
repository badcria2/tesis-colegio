using Comunes_Datos;
using Servicio_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO; 
using System.Web;

namespace Educacion_Datos
{
    public class EDU_ForoDAL
    {
        #region Singleton
        private static readonly EDU_ForoDAL _instancia = new EDU_ForoDAL();
        public static EDU_ForoDAL Instancia
        {
            get { return EDU_ForoDAL._instancia; }
        }
        #endregion Singleton

        public List<SER_ForoEL> GetForo(String codigoClase, String codigoUsuario)
        {
            SqlCommand cmd = null;
            List<SER_ForoEL> _ForoELs = new List<SER_ForoEL>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerForo", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_usuario", codigoUsuario);
                cmd.Parameters.AddWithValue("@codigo_clase", codigoClase);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _ForoELs.Add(
                        new SER_ForoEL()
                        {
                            codigo = dr["codigo_foro"].ToString(),
                            clase = dr["codigo_clase"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                            fechaCreacion = dr["fecha_creacion"].ToString(),
                            respondio = Int32.Parse(dr["respondido"].ToString()) > 0 ? true: false,
                            cantidadRespuestas = Int32.Parse(dr["cantidad_respuestas"].ToString()),
                            tema = dr["tema"].ToString(),
                            creador = dr["creador"].ToString()
                        }
                 );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return _ForoELs;
        }

        public List<SER_ForoBaseEL> GetForoDetalle(String codigoForo)
        {
            SqlCommand cmd = null;
            List<SER_ForoBaseEL> _ForoELs = new List<SER_ForoBaseEL>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerForoDetalle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_foro", codigoForo); 
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StringWriter myWriter = new StringWriter();
                    HttpUtility.HtmlDecode(dr["descripcion"].ToString(), myWriter);
                    _ForoELs.Add(
                        new SER_ForoBaseEL()
                        {
                            codigo = dr["codigo_foro"].ToString(),
                            clase = dr["codigo_clase"].ToString(),
                            descripcion = myWriter.ToString(),
                            fechaCreacion = dr["fecha_creacion"].ToString(),
                            tema = dr["tema"].ToString(),
                            sexo = dr["sexo"].ToString(),
                            creador = dr["creador"].ToString()
                        }
                 );
                } 
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return _ForoELs;
        }

        public Boolean InsertForo(String codigoClase, String tema, String descripcion, String temaPadre, String usuario)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_InsertForo", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoClase", codigoClase);
                cmd.Parameters.AddWithValue("@tema", tema);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@temaPadre", temaPadre);
                cmd.Parameters.AddWithValue("@usuario", usuario); 
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
