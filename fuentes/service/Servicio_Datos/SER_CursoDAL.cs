using Comunes_Datos;
using Servicio_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Servicio_Datos
{
    public class SER_CursoDAL
    {
        #region Singleton
        private static readonly SER_CursoDAL _instancia = new SER_CursoDAL();
        public static SER_CursoDAL Instancia
        {
            get { return SER_CursoDAL._instancia; }
        }
        #endregion Singleton

        public List<SER_CursoEL> DevolverCursos(String usuario, String periodo)
        {
            SqlCommand cmd = null;
            List<SER_CursoEL> _CursoELs = new List<SER_CursoEL>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerCursos", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_usuario", usuario);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _CursoELs.Add(
                        new SER_CursoEL()
                        {
                            codigo = dr["codigo_curso"].ToString(),
                            nombre = dr["nombre_curso"].ToString(),
                            periodo = dr["periodo"].ToString(),
                            grado = Char.Parse(dr["grado"].ToString()),
                            seccion = Char.Parse(dr["seccion"].ToString()),
                            estado = dr["estado_curso_alumno"].ToString(),
                            estilo = dr["estilo"].ToString()
                        }
                    );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return _CursoELs;
        }

    }
}
