using Comunes_Datos;
using Servicio_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Servicio_Datos
{
    public class SER_AvisoDAL
    {
        #region Singleton
        private static readonly SER_AvisoDAL _instancia = new SER_AvisoDAL();
        public static SER_AvisoDAL Instancia
        {
            get { return SER_AvisoDAL._instancia; }
        }
        #endregion Singleton

        public List<SER_AvisoEL> GetAvisos()
        {
            SqlCommand cmd = null;
            List<SER_AvisoEL> _AvisoELs = new List<SER_AvisoEL>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerAvisos", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _AvisoELs.Add(
                        new SER_AvisoEL()
                        {
                            codigo = dr["codigo"].ToString(),
                            titulo = dr["titulo"].ToString(),
                            contenido = dr["contenido"].ToString(),
                            codigoUsuario = dr["codigo_usuario"].ToString(),
                            fechaInicio = dr["fechaInicio"].ToString(),
                            fechaTermino = dr["fechaTermino"].ToString(),
                            imagen = dr["imagen"].ToString(),
                            importancia = Int32.Parse(dr["importancia"].ToString()),
                            nombres = dr["nombres"].ToString(),
                            apellidos = dr["apellidos"].ToString(),
                            estado = Boolean.Parse(dr["estado"].ToString())
                        }
                    );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return _AvisoELs;
        }
        public Boolean InsertarAvisos(String titulo, String contenido, String imagen, String codigoAviso, String fechaInicio, String fechaFin, String usuario)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_InsertarAviso", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@contenido", contenido);
                cmd.Parameters.AddWithValue("@imagen", imagen);
                cmd.Parameters.AddWithValue("@codigo_aviso", null == codigoAviso ? "0" : codigoAviso);
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaTermino", fechaFin);
                cmd.Parameters.AddWithValue("@codigoUsuario", usuario); 
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
