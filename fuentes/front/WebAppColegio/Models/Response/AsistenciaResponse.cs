using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class AsistenciaResponse : Persona
    {
        public String codigo { get; set; }
        public String numeroFaltas { get; set; }
        public Asistencia asistencia { get; set; }
    }
    public class Asistencia
    {
        public String codigo { get; set; }
        public String clase { get; set; }
        public String usuario { get; set; }
        public String fechaRegistro { get; set; }
        public Char estado { get; set; }
    }
}
