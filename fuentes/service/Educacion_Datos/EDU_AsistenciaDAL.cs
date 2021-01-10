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
                            usuario = dr["usuario"].ToString(),
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
                        asistencia = asistencia.FindAll(x => x.usuario == dr["codigo_alumno"].ToString())
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

        public List<EDU_AsistenciaEL> asistenciaDefault()
        {
            var asistencia = new List<EDU_AsistenciaEL>();
            asistencia.Add(new EDU_AsistenciaEL() { estado = 'F' });
            return asistencia;
        }
    }

}
