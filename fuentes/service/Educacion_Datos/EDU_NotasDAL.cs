using Comunes_Datos;
using Educacion_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace Educacion_Datos
{

    public class EDU_NotasDAL
    {
        #region Singleton
        private static readonly EDU_NotasDAL _instancia = new EDU_NotasDAL();
        public static EDU_NotasDAL Instancia
        {
            get { return EDU_NotasDAL._instancia; }
        }
        #endregion Singleton

        public List<EDU_CursoEL> GetNotas(String periodo, String codigoUsuario)
        {
            SqlCommand comando = null;
            List<EDU_CursoEL> cursoReturn = new List<EDU_CursoEL>();
            List<EDU_CursoEL> eDU_CursoELs = new List<EDU_CursoEL>();
            List<EDU_TipoNotaEL> eDU_TipoNotaELs = new List<EDU_TipoNotaEL>();
            List<EDU_NotasEL> eDU_NotasELs = new List<EDU_NotasEL>();
            try
            {

                SqlConnection cn = Conexion.Instancia.Conectar();
                comando = new SqlCommand("PRD_ObtenerNotasAlumno", cn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo_alumno", codigoUsuario);
                comando.Parameters.AddWithValue("@periodo", periodo);
                cn.Open();
                SqlDataReader dataAccessReader = comando.ExecuteReader();

                while (dataAccessReader.Read())
                {
                    eDU_CursoELs.Add(new EDU_CursoEL()
                    {
                        codigo = dataAccessReader["codigo_curso"].ToString(),
                        nombre = dataAccessReader["nombre_curso"].ToString()
                    });
                }

                // this advances to the next resultset 
                dataAccessReader.NextResult();
                while (dataAccessReader.Read())
                {
                    eDU_TipoNotaELs.Add(new EDU_TipoNotaEL()
                    {
                        codigo = dataAccessReader["codigo"].ToString(),
                        nombre = dataAccessReader["descripcion"].ToString()

                    });
                }
                dataAccessReader.NextResult();
                while (dataAccessReader.Read())
                {
                    eDU_NotasELs.Add(new EDU_NotasEL()
                    {
                        codigoCurso = dataAccessReader["codigo_curso"].ToString(),
                        nota = Int32.Parse(dataAccessReader["nota"].ToString()),
                        tipoCalificacion = dataAccessReader["tipo"].ToString(),
                        registro = true
                    });
                }
                cursoReturn = returnListTransForm(eDU_CursoELs, eDU_TipoNotaELs, eDU_NotasELs);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { comando.Connection.Close(); }
            return cursoReturn;
        }
        public List<EDU_NotasEL> notasDefault(List<EDU_NotasEL> lst)
        {

            while (lst.Count < 3)
            {
                lst.Add(new EDU_NotasEL() { nota = 0, registro = false });
            }
            return lst;
        }

        public List<EDU_CursoEL> returnListTransForm(List<EDU_CursoEL> eDU_CursoELs, List<EDU_TipoNotaEL> eDU_TipoNotaELs, List<EDU_NotasEL> eDU_NotasELs)
        {
            var lstCursos = new List<EDU_CursoEL>();
            var lstNotas = new List<EDU_NotasEL>();
            CultureInfo culture = new CultureInfo("en-US");
            foreach (var curso in eDU_CursoELs)
            {
                curso.tipoNota = eDU_TipoNotaELs;
            }
            foreach (var curso in eDU_CursoELs)
            {
                var lstTipoNotas = new List<EDU_TipoNotaEL>();
                foreach (var tipoNota in eDU_TipoNotaELs)
                {
                    lstNotas = eDU_NotasELs.FindAll(e => e.tipoCalificacion == tipoNota.codigo && e.codigoCurso == curso.codigo);
                    var suma = (Decimal)(eDU_NotasELs.FindAll(e => e.tipoCalificacion == tipoNota.codigo && e.codigoCurso == curso.codigo).Select(x => x.nota).Sum());
                    lstTipoNotas.Add(new EDU_TipoNotaEL() { codigo = tipoNota.codigo, nombre = tipoNota.nombre, nota = (notasDefault(lstNotas)), promedio = Decimal.Divide(suma, 3).ToString("0.##").Replace(",", ".") });
                }
                var promedio = Decimal.Divide(lstTipoNotas.Select(x => Decimal.Parse(x.promedio, culture)).Sum(), 3);
                var cursoTemp = new EDU_CursoEL() { codigo = curso.codigo, nombre = curso.nombre, tipoNota = lstTipoNotas, promedio = promedio.ToString("0.##").Replace(",", ".") };
                lstCursos.Add(cursoTemp);
            }
            return lstCursos;
        }
    }

}
