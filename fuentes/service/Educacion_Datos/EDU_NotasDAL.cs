using Comunes_Datos;
using Educacion_Entidades;
using Persona_Entidades;
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

        public List<PER_AlumnoEL> GetNotasDocente(String periodo, String codigoClase, String codigoDocente)
        {
            SqlCommand comando = null;
            var cursoReturn = new List<PER_AlumnoEL>();
            var pER_AlumnoELs = new List<PER_AlumnoEL>();
            var eDU_TipoNotaELs = new List<EDU_TipoNotaEL>();
            var eDU_NotasELs = new List<EDU_NotasEL>();
            try
            {

                SqlConnection cn = Conexion.Instancia.Conectar();
                comando = new SqlCommand("PRD_ObtenerNotasDocente", cn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo_clase", codigoClase);
                comando.Parameters.AddWithValue("@periodo", periodo);
                comando.Parameters.AddWithValue("@codigo_docente", codigoDocente);
                cn.Open();
                SqlDataReader dataAccessReader = comando.ExecuteReader();

                while (dataAccessReader.Read())
                {
                    pER_AlumnoELs.Add(new PER_AlumnoEL()
                    {

                        nombres = dataAccessReader["nombres"].ToString(),
                        apellidos = dataAccessReader["apellidos"].ToString(),
                        codigo = dataAccessReader["codigo_alumno"].ToString()

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
                        codigoAlumno = dataAccessReader["codigo_alumno"].ToString(),
                        nota = Int32.Parse(dataAccessReader["nota"].ToString()),
                        tipoCalificacion = dataAccessReader["tipo"].ToString(),
                        registro = true
                    });
                }
                cursoReturn = returnListTransFormDocente(pER_AlumnoELs, eDU_TipoNotaELs, eDU_NotasELs);

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

        public List<PER_AlumnoEL> returnListTransFormDocente(List<PER_AlumnoEL> pER_AlumnoELs, List<EDU_TipoNotaEL> eDU_TipoNotaELs, List<EDU_NotasEL> eDU_NotasELs)
        {
            var alumnoELs = new List<PER_AlumnoEL>();
            var lstNotas = new List<EDU_NotasEL>();
            CultureInfo culture = new CultureInfo("en-US");
            foreach (var alumno in pER_AlumnoELs)
            {
                alumno.tipoNota = eDU_TipoNotaELs;
            }
            foreach (var alumno in pER_AlumnoELs)
            {
                var lstTipoNotas = new List<EDU_TipoNotaEL>();
                foreach (var tipoNota in eDU_TipoNotaELs)
                {
                    lstNotas = eDU_NotasELs.FindAll(e => e.tipoCalificacion == tipoNota.codigo && e.codigoAlumno == alumno.codigo);
                    var suma = (Decimal)(eDU_NotasELs.FindAll(e => e.tipoCalificacion == tipoNota.codigo && e.codigoAlumno == alumno.codigo).Select(x => x.nota).Sum());
                    lstTipoNotas.Add(new EDU_TipoNotaEL() { codigo = tipoNota.codigo, nombre = tipoNota.nombre, nota = (notasDefault(lstNotas)) });
                }
                var cursoTemp = new PER_AlumnoEL()
                {
                    codigo = alumno.codigo,
                    nombres = alumno.nombres,
                    apellidos = alumno.apellidos,
                    tipoNota = lstTipoNotas
                };
                alumnoELs.Add(cursoTemp);
            }
            for (int i = 0; i < alumnoELs.Count; i++)
            {
                List<String> lstPromedios = new List<String>();
                var nota1 = alumnoELs[i].tipoNota[0].nota[0].nota;
                var nota2 = alumnoELs[i].tipoNota[1].nota[0].nota;
                var nota3 = alumnoELs[i].tipoNota[2].nota[0].nota;
                var promedio1 = Decimal.Divide(nota1 + nota2 + nota3, 3);
                lstPromedios.Add(promedio1.ToString("0.##").Replace(",", "."));
                alumnoELs[i].promedio = lstPromedios;

                var nota4 = alumnoELs[i].tipoNota[0].nota[1].nota;
                var nota5 = alumnoELs[i].tipoNota[1].nota[1].nota;
                var nota6 = alumnoELs[i].tipoNota[2].nota[1].nota;
                var promedio2 = Decimal.Divide(nota4 + nota6 + nota5, 3);
                lstPromedios.Add(promedio2.ToString("0.##").Replace(",", "."));
                alumnoELs[i].promedio = lstPromedios;

                var nota7 = alumnoELs[i].tipoNota[0].nota[2].nota;
                var nota8 = alumnoELs[i].tipoNota[1].nota[2].nota;
                var nota9 = alumnoELs[i].tipoNota[2].nota[2].nota;
                var promedio3 = Decimal.Divide(nota7 + nota8 + nota9, 3);
                lstPromedios.Add(promedio3.ToString("0.##").Replace(",", "."));
                alumnoELs[i].promedio = lstPromedios;


                alumnoELs[i].promedioGeneral = Decimal.Divide(promedio1 + promedio2 + promedio3, 3).ToString("0.##");

            }
            return alumnoELs;
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
                    lstTipoNotas.Add(new EDU_TipoNotaEL() { codigo = tipoNota.codigo, nombre = tipoNota.nombre, nota = (notasDefault(lstNotas)) });
                }
                var cursoTemp = new EDU_CursoEL() { codigo = curso.codigo, nombre = curso.nombre, tipoNota = lstTipoNotas };
                lstCursos.Add(cursoTemp);
            }
            for (int i = 0; i < lstCursos.Count; i++)
            {
                List<String> lstPromedios = new List<String>();
                var nota1 = lstCursos[i].tipoNota[0].nota[0].nota;
                var nota2 = lstCursos[i].tipoNota[1].nota[0].nota;
                var nota3 = lstCursos[i].tipoNota[2].nota[0].nota;
                var promedio1 = Decimal.Divide(nota1 + nota2 + nota3, 3);
                lstPromedios.Add(promedio1.ToString("0.##").Replace(",", "."));
                lstCursos[i].promedio = lstPromedios;

                var nota4 = lstCursos[i].tipoNota[0].nota[1].nota;
                var nota5 = lstCursos[i].tipoNota[1].nota[1].nota;
                var nota6 = lstCursos[i].tipoNota[2].nota[1].nota;
                var promedio2 = Decimal.Divide(nota4 + nota6 + nota5, 3);
                lstPromedios.Add(promedio2.ToString("0.##").Replace(",", "."));
                lstCursos[i].promedio = lstPromedios;

                var nota7 = lstCursos[i].tipoNota[0].nota[2].nota;
                var nota8 = lstCursos[i].tipoNota[1].nota[2].nota;
                var nota9 = lstCursos[i].tipoNota[2].nota[2].nota;
                var promedio3 = Decimal.Divide(nota7 + nota8 + nota9, 3);
                lstPromedios.Add(promedio3.ToString("0.##").Replace(",", "."));
                lstCursos[i].promedio = lstPromedios;


                lstCursos[i].promedioGeneral = Decimal.Divide(promedio1 + promedio2 + promedio3, 3).ToString("0.##");

            }
            return lstCursos;
        }

        public Boolean RegisterNotas(String nota, String clase, String tipo, int eliminar)
        {

            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("PRD_InsertarNotas", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nota", nota);
                cmd.Parameters.AddWithValue("@clase", clase);
                cmd.Parameters.AddWithValue("@tipo_nota", tipo);
                cmd.Parameters.AddWithValue("@eliminar", eliminar);
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    inserto = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserto;
        }
    }

}
