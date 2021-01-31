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

        public List<SER_TareaEL> GetTarea(String codigoClase, String periodo, String codigoUsuario)
        {
            SqlCommand cmd = null;
            List<SER_TareaEL> _TareaELs = new List<SER_TareaEL>();
            try
            { 
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerTareas", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_clase", codigoClase);
                cmd.Parameters.AddWithValue("@codigo_usuario", codigoUsuario);
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
        public Boolean InsertTarea(EDU_MaterialEL eDU_MaterialEL)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_InsertarTareas", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_clase", eDU_MaterialEL.codigo);
                cmd.Parameters.AddWithValue("@semana", eDU_MaterialEL.semana);
                cmd.Parameters.AddWithValue("@mes", eDU_MaterialEL.mes);
                cmd.Parameters.AddWithValue("@nombre_tarea", eDU_MaterialEL.nombre);
                cmd.Parameters.AddWithValue("@usuario", eDU_MaterialEL.usuario);
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
        public Boolean InsertMaterial(EDU_MaterialEL eDU_MaterialEL)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_InsertarMaterial", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_clase", eDU_MaterialEL.codigo);
                cmd.Parameters.AddWithValue("@semana", eDU_MaterialEL.semana);
                cmd.Parameters.AddWithValue("@mes", eDU_MaterialEL.mes);
                cmd.Parameters.AddWithValue("@nombre_material", eDU_MaterialEL.nombre);
                cmd.Parameters.AddWithValue("@usuario", eDU_MaterialEL.usuario);
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
        public Boolean DeleteDocumento(String codigo, String tipo)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_EliminarDocumento", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@tipo", tipo);
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

        public List<SER_TareaEL> ObtenerTareasDocente(String codigoClase, int semana, String mes, String periodo)
        {
            List<SER_TareaEL> sER_TareaELs = new List<SER_TareaEL>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_ObtenerTareasDocente", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_clase", codigoClase);
                cmd.Parameters.AddWithValue("@semana", semana);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@periodo", periodo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sER_TareaELs.Add(
                        new SER_TareaEL()
                        {
                            codigo = dr["codigo_tarea"].ToString(),
                            nombre = dr["nombre_tarea"].ToString(),
                            alumno = dr["alumno"].ToString()
                        }
                 );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return sER_TareaELs;
        }
    }

}
