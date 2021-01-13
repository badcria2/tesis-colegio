using Comunes_Datos;
using Educacion_Entidades;
using Persona_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Educacion_Datos
{
    public class EDU_AsistenciaDAL
    {
        #region Singleton
        private static readonly EDU_AsistenciaDAL _instancia = new EDU_AsistenciaDAL();
        public static EDU_AsistenciaDAL Instancia
        {
            get { return EDU_AsistenciaDAL._instancia; }
        }
        #endregion Singleton

        public List<PER_AsistenteEL> GetAsistencia(String codigoClase, String codigoUsuario, String fechaRegistro, String periodo)
        {
            SqlCommand cmd = null;
            var asistencia = new List<EDU_AsistenciaEL>();
            var _AsistenteELs = new List<PER_AsistenteEL>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerAsistencia", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_usuario", codigoUsuario);
                cmd.Parameters.AddWithValue("@codigo_clase", codigoClase);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cmd.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    asistencia.Add(
                        new EDU_AsistenciaEL()
                        {
                            codigo = dr["codigo_asistencia"].ToString(),
                            clase = dr["codigo_clase"].ToString(),
                            estado = Char.Parse(dr["estado"].ToString()),
                            fechaRegistro = dr["fecha_registro"].ToString(),
                            usuario = dr["usuario"].ToString()
                        }
                 );
                }
                dr.NextResult();
                while (dr.Read())
                {
                    _AsistenteELs.Add(new PER_AsistenteEL()
                    {
                        codigo = dr["codigo_alumno"].ToString(),
                        nombres = dr["nombres"].ToString(),
                        apellidos = dr["apellidos"].ToString(),
                        numeroFaltas = dr["faltas"].ToString(),
                        asistencia = asistencia.Where(m => m.usuario == dr["codigo_alumno"].ToString())
                             .DefaultIfEmpty(asistenciaDefault()).First() 
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return _AsistenteELs;
        }

        public EDU_AsistenciaEL asistenciaDefault()
        {
            
            return new EDU_AsistenciaEL() { estado = 'N' , numeroFaltas = "0"};
        }


        public Boolean InsertAsistencia(Char estado, String codigoClase, String usuario, String fechaRegistro)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            var _AsistenteELs = new List<PER_AsistenteEL>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_InsertarAsistencia", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@clase", codigoClase);
                cmd.Parameters.AddWithValue("@codigo_usuario", usuario);
                cmd.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);
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
