using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class ForoResponse : ForoBase
    {
        public Boolean respondio { get; set; }
        public int cantidadRespuestas { get; set; }
    }
}
