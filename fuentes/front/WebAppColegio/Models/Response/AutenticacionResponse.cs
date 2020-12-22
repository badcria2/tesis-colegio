using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppColegio.Models.Response
{
    public class AutenticacionResponse
    {
        public String codigoUsuario { get; set; }
        public String perfil { get; set; }
        public String codigoTipoAcceso { get; set; }
        public Persona persona { get; set; }
        public List<TipoAcceso> permisos { get; set; } 
        public Boolean estado { get; set; }
    }
}
