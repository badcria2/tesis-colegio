using Comunes_Negocio;
using Seguridad_Datos;
using Seguridad_Entidades;
using System;

namespace Seguridad_Negocio
{
    public class SEG_UsuarioBL
    {
        #region Singleton
        private static readonly SEG_UsuarioBL _instancia = new SEG_UsuarioBL();
        public static SEG_UsuarioBL Instancia
        {
            get { return SEG_UsuarioBL._instancia; }
        }
        #endregion Singleton
        public SEG_UsuarioEL DevolverUsuario(String usuario, String password)
        {
            try
            {
                var usuarioResponse =  SEG_UsuarioDAL.Instancia.DevolverUsuario(usuario, password);
                if(usuarioResponse != null)
                    usuarioResponse.permisos = CMM_TipoAccesoBL.Instancia.ObtenerPermisos(usuarioResponse.perfil);
                return usuarioResponse;
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
