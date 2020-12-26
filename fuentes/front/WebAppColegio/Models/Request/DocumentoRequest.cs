using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Request
{
    public class DocumentoRequest
    {
        public String codigoClase { get; set; }
        public String nombre { get; set; }
        public int semana { get; set; }
        public String origen { get; set; }
        public String usuario { get; set; }
    }
}
