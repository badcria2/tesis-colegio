using Educacion_Datos;
using Educacion_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educacion_Negocio
{
    public class EDU_NotasBL
    {
        #region Singleton
        private static readonly EDU_NotasBL _instancia = new EDU_NotasBL();
        public static EDU_NotasBL Instancia
        {
            get { return EDU_NotasBL._instancia; }
        }
        #endregion Singleton
        public EDU_NotasCurso GetNotas(String periodo, String codigoUsuario)
        {
            try
            {
                return EDU_NotasDAL.Instancia.GetNotas( periodo, codigoUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
