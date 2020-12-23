using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class CursoResponse
    {
        public String codigo { get; set; }
        public String nombre { get; set; }
        public Char grado { get; set; }
        public Char seccion { get; set; }
        public String periodo { get; set; }
        public String estado { get; set; }
    }
}
