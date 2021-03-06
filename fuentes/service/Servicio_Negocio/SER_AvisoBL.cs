﻿using Servicio_Datos;
using Servicio_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio_Negocio
{
    public class SER_AvisoBL
    {
        #region Singleton
        private static readonly SER_AvisoBL _instancia = new SER_AvisoBL();
        public static SER_AvisoBL Instancia
        {
            get { return SER_AvisoBL._instancia; }
        }
        #endregion Singleton
        public List<SER_AvisoEL> GetAvisos()
        {
            try
            {
                return SER_AvisoDAL.Instancia.GetAvisos();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertAviso(String titulo, String contenido, String imagen, String codigoAviso, String fechaInicio, String fechaFin, String usuario)
        {
            try
            {
                return SER_AvisoDAL.Instancia.InsertarAvisos( titulo,  contenido,  imagen,  codigoAviso,  fechaInicio,  fechaFin,  usuario);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
