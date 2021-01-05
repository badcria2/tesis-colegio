
using System;
using System.Collections.Generic;
using System.Text;

namespace Educacion_Entidades
{
    public class EDU_CursoEL
    {
        public String codigo { get; set; }
        public String nombre { get; set; }
        public String promedio { get; set; }
        public List<EDU_TipoNotaEL> tipoNota { get; set; }

    }
}