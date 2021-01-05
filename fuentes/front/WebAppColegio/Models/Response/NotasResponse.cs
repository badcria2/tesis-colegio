using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class NotasResponse
    {
        public String codigo { get; set; }
        public String nombre { get; set; }
        public List<String> promedio { get; set; }
        public List<TipoNota> tipoNota { get; set; }
        public String promedioGeneral { get; set; }
    }
}
