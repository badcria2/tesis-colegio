using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Request
{
    public class AsistenciaRequest : BaseRequest
    {
        public String clase { get; set; }
        public String fechaRegistro { get; set; }


        public Char estado { get; set; }
         
    }
}
