using Comunes_Entidades;
using Persona_Entidades;
using System;
using System.Collections.Generic;

namespace Seguridad_Entidades
{
    public class SEG_UsuarioEL
    {
        public String codigoUsuario { get; set; } 
        public String perfil { get; set; }
        public String codigoTipoAcceso { get; set; }
        public PER_PersonalEL persona { get; set; }
        public List<CMM_TipoAccesoEL> permisos { get; set; }
        public Boolean estado { get; set; }
    }
}
 