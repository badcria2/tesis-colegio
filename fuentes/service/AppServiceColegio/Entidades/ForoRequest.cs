using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceColegio.Entidades
{
    public class ForoRequest : BaseRequest
    {
        public String codigoClase { get; set; }
        public String codigoForo { get; set; }
        public String tema { get; set; }
        public String descripcion { get; set; }
        public String temaPadre { get; set; }
         
    }
}
