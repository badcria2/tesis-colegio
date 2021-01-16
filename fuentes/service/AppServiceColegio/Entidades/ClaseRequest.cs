using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceColegio.Entidades
{
    public class ClaseRequest : BaseRequest
    {

        public String enlace { get; set; }
        public String codigo { get; set; }
        public String fechaInicio { get; set; }
        public String fechaFin { get; set; }
        public int semana { get; set; }
        public String mes { get; set; }
    }
}
