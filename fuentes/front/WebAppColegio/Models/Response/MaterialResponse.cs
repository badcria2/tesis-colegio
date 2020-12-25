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
        public String extension { get; set; }
        public String nombre { get; set; }
    }
}
