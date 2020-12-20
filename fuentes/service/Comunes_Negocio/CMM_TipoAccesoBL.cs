﻿using Comunes_Datos;
using Comunes_Entidades;
using System;
using System.Collections.Generic;

namespace Comunes_Negocio
{
    public class CMM_TipoAccesoBL
    {
        #region Singleton
        private static readonly CMM_TipoAccesoBL _instancia = new CMM_TipoAccesoBL();
        public static CMM_TipoAccesoBL Instancia
        {
            get { return CMM_TipoAccesoBL._instancia; }
        }
        #endregion Singleton
        public List<CMM_TipoAccesoEL> ObtenerPermisos(String Perfil)
        {
            try
            {
                return CMM_TipoAccesoDAL.Instancia.ObtenerPermisos(Perfil);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}