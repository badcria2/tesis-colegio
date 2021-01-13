using Educacion_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persona_Entidades
{
    public class PER_AsistenteEL : PER_PersonalEL
    {
        public String codigo { get; set; }
        public String numeroFaltas { get; set; }
        public EDU_AsistenciaEL asistencia { get; set; }
    }
}
