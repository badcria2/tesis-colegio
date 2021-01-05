using Educacion_Datos;
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
        public List<SER_TareaEL> GetTareas(String codigoClase, String periodo, String codigoUsuario)
        {
            try
            {
                return EDU_TareaDAL.Instancia.GetTarea(codigoClase, periodo, codigoUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertTarea(String codigoClase, String nombre, int semana, String origen, String usuario, String mes)
        {
            try
            {
                switch (origen)
                {
                    case "Docente":
                        return EDU_TareaDAL.Instancia.InsertMaterial(new EDU_MaterialEL() { codigo = codigoClase, nombre = nombre, semana = semana, usuario = usuario , mes= mes});
                    case "Alumno":
                        return EDU_TareaDAL.Instancia.InsertTarea(new EDU_MaterialEL() { codigo = codigoClase, nombre = nombre, semana = semana, usuario = usuario, mes = mes });
                    default: return false;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean DeleteDocumento(String codigo, String tipo)
        {
            try
            {
                return EDU_TareaDAL.Instancia.DeleteDocumento(codigo, tipo);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
