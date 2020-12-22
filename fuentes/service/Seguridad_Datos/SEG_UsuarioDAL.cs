using Comunes_Datos;
using Seguridad_Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Seguridad_Datos
{
    public class SEG_UsuarioDAL
    {
        #region Singleton
        private static readonly SEG_UsuarioDAL _instancia = new SEG_UsuarioDAL();
        public static SEG_UsuarioDAL Instancia
        {
            get { return SEG_UsuarioDAL._instancia; }
        }
        #endregion Singleton

        public SEG_UsuarioEL DevolverUsuario(String usuario, String password)
        {
            SqlCommand cmd = null;
            SEG_UsuarioEL usuarioEL = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_AccesoUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuarioEL = new SEG_UsuarioEL();
                    usuarioEL.codigoUsuario = dr["codigoUsuario"].ToString();
                    usuarioEL.codigoTipoAcceso = dr["codigoTipoAcceso"].ToString();
                    usuarioEL.perfil = dr["acceso"].ToString();
                    usuarioEL.estado = Boolean.Parse(dr["estado"].ToString());
                    usuarioEL.persona = new Persona_Entidades.PER_PersonalEL()
                    {
                        apellidos = dr["apellidos"].ToString(),
                        nombres = dr["nombres"].ToString(),
                        dni = dr["dni"].ToString(),
                        sexo = Char.Parse(dr["sexo"].ToString())
                    };
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return usuarioEL;
        }

    }
}
