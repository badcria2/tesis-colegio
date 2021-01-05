using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models
{
    public class CursoRequest
    {
        public String usuario { get; set; }
        public String periodo { get; set; }
        public String perfil { get; set; }
        public String grado { get; set; }
        public String seccion { get; set; }
    }
}
