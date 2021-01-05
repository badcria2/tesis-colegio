using System;
using System.Collections.Generic;
using System.Text;

namespace Educacion_Entidades
{
    public class EDU_TipoNotaEL 
    {
        public String codigo { get; set; }
        public String nombre { get; set; } 
        public List<EDU_NotasEL> nota { get; set; }

    }
}
