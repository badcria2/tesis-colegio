using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio_Entidades
{
    public class SER_MaterialEL
    {
        public String codigo { get; set; }
        public int nroSemana { get; set; }
        public String extension { get; set; }
        public String nombre { get; set; }
        public Boolean tareaHabilitada { get; set; }
        public String tiempoRestante { get; set; }
        public String mes { get; set; }
        public SER_TareaEL tarea { get; set; }


    }
}
