using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class MaterialResponse
    {
        public String codigo { get; set; }
        public int nroSemana { get; set; }
        public String mes { get; set; }
        public String extension { get; set; }
        public String nombre { get; set; }
        public Boolean tareaHabilitada { get; set; }
        public String tiempoRestante { get; set; }
        public Tarea tarea { get; set; }
        public String fechaInicioTarea { get; set; }
        public String fechaFinTarea { get; set; }
    }
}
