using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceColegio.Entidades
{
    public class AsistenciaRequest: BaseRequest
    {
        public String clase { get; set; } 
        public String fechaRegistro { get; set; }


      
    }
}
