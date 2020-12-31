using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class AvisosResponse
    {
        public String codigo { get; set; }
        public String titulo { get; set; }
        public String contenido { get; set; }
        public String codigoUsuario { get; set; }
        public Boolean estado { get; set; }
        public String fechaInicio { get; set; }
        public String fechaTermino { get; set; }
        public String imagen { get; set; }
        public int importancia { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }

        public String uri { get; set; }
    }
}
