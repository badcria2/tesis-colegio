using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class TipoNota
    {
        public String codigo { get; set; }
        public String nombre { get; set; }
        public String promedio { get; set; }
        public List<Nota> nota { get; set; }
    }
}
