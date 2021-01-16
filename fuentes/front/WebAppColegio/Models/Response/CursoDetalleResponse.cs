using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class CursoDetalleResponse
    {
        public String codigo { get; set; }
        public String enlace { get; set; }
        public String cursoNombre { get; set; }
        public int numeroSemanas { get; set; }
        public List<MaterialResponse> material { get; set; }
        public List<Periodo> periodos { get; set; }
        public Boolean estado { get; set; }
        public Boolean alerta { get; set; }
    }
}
