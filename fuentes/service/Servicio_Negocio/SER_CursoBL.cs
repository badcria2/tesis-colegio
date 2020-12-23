using Servicio_Datos;
using Servicio_Entidades;
using System;
using System.Collections.Generic;

namespace Servicio_Negocio
{
    public class SER_CursoBL
    {
        #region Singleton
        private static readonly SER_CursoBL _instancia = new SER_CursoBL();
        public static SER_CursoBL Instancia
        {
            get { return SER_CursoBL._instancia; }
        }
        #endregion Singleton
        public List<SER_CursoEL> DevolverCursos(String usuario, String periodo)
        {
            try
            {
                var _CursoELs = SER_CursoDAL.Instancia.DevolverCursos(usuario, periodo); 
                return _CursoELs;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
