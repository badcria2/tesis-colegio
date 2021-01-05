using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceColegio.Entidades
{
    public class AvisoRequest
    {
        public String titulo { get; set; }
        public String contenido { get; set; }
        public String imagen { get; set; }
        public String codigoAviso { get; set; }
        public String fechaInicio { get; set; }
        public String fechaFin { get; set; }
        public String usuario { get; set; } 
    }
}
