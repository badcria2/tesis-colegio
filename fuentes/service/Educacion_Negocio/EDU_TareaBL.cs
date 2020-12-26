﻿using Educacion_Datos;
using Educacion_Entidades;
using Servicio_Entidades;
using System;
using System.Collections.Generic;

namespace Educacion_Negocio
{
    public class EDU_TareaBL
    {
        #region Singleton
        private static readonly EDU_TareaBL _instancia = new EDU_TareaBL();
        public static EDU_TareaBL Instancia
        {
            get { return EDU_TareaBL._instancia; }
        }
        #endregion Singleton
        public List<SER_TareaEL> GetTareas(String codigoClase, String periodo)
        {
            try
            {
                return EDU_TareaDAL.Instancia.GetTarea(codigoClase, periodo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertTarea(EDU_TareaEL eDU_TareaEL)
        {
            try
            {
                return EDU_TareaDAL.Instancia.InsertTarea(eDU_TareaEL);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}