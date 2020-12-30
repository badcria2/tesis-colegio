using System;
using System.Collections.Generic;
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
    }
   
}
