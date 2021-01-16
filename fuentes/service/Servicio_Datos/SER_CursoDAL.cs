using Comunes_Datos;
using Educacion_Entidades;
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

        public List<SER_CursoEL> GetCurso(String usuario, String periodo, String perfil, String grado, String seccion)
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
                cmd.Parameters.AddWithValue("@perfil", perfil);
                cmd.Parameters.AddWithValue("@grado", grado);
                cmd.Parameters.AddWithValue("@seccion", seccion);
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
                            estilo = dr["estilo"].ToString(),
                            clase = dr["codigo_clase"].ToString()
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
        public SER_DetCursoEL GetDetCurso(String codigoClase, String periodo)
        {
            SqlCommand cmd = null;
            SER_DetCursoEL _CursoELs = new SER_DetCursoEL();
            List<SER_MaterialEL> _MaterialELs = new List<SER_MaterialEL>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerDetalleCurso", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_clase", codigoClase);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _CursoELs.codigo = dr["codigo_clase"].ToString();
                    _CursoELs.enlace = dr["enlace"].ToString();
                    _CursoELs.numeroSemanas = Int32.Parse(dr["numero_semanas"].ToString());
                    if (!String.IsNullOrEmpty(dr["codigo_material"].ToString()))
                    {
                        _MaterialELs.Add(

                        new SER_MaterialEL()
                        {
                            codigo = dr["codigo_material"].ToString(),
                            nombre = dr["nombre_material"].ToString(),
                            nroSemana = Int32.Parse(dr["semana"].ToString()),
                            extension = dr["extension"].ToString(),
                            mes = dr["mes"].ToString(),
                            tareaHabilitada = Boolean.Parse(dr["tarea_habilitada"].ToString()),
                            tiempoRestante = dr["tiempo_restante"].ToString(),
                            fechaFinTarea = dr["fecha_fin_clase"].ToString(),
                            fechaInicioTarea =  dr["fecha_inicio_tarea"].ToString(),
                            tarea = new SER_TareaEL() { codigo = "", nombre = "", nroSemana = 0 }
                        });
                    }
                    _CursoELs.material = _MaterialELs;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return _CursoELs;
        }

        public Boolean UpdateClase(String codigoClase, String periodo, String fechaFin , String fechaInicio, String enlace, String mes = "", int semana = 0)
        {
            SqlCommand cmd = null;
            Boolean actualizo = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ActualizarDetalleCurso", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_clase", codigoClase);
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@enlace", enlace); 
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@semana", semana);
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    actualizo = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return actualizo;
        }

    }
}
