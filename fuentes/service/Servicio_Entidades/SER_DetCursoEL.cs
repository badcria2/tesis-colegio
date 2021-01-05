using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio_Entidades
{
    public class SER_DetCursoEL
    {
        public String codigo { get; set; }
        public String enlace { get; set; }
        public int numeroSemanas { get; set; }
        public List<SER_MaterialEL> material { get; set; }

        
    
        
    }
}
