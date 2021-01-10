using Educacion_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persona_Entidades
{
    public class PER_AlumnoEL : PER_PersonalEL
    {
        public String codigo { get; set; }
        public List<EDU_TipoNotaEL> tipoNota { get; set; }
        public List<String> promedio { get; set; }
        public String promedioGeneral { get; set; }
    }
}
