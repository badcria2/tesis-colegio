using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class ForoBase
    {

        public String clase { get; set; }
        public String fechaCreacion { get; set; }
        public String tema { get; set; }
        public String descripcion { get; set; }
        public String codigo { get; set; }
        public String creador { get; set; } 
        public String sexo { get; set; }

    }
}
