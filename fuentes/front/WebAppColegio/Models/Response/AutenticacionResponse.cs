using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class AutenticacionResponse
    {
        public String codigoUsuario { get; set; }
        public String Perfil { get; set; }
        public String codigoTipoAcceso { get; set; }
        public Persona Persona { get; set; }
        public List<TipoAcceso> Permisos { get; set; }

        public Boolean Estado { get; set; }
    }
}
