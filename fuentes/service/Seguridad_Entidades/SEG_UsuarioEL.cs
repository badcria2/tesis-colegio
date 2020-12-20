using Comunes_Entidades;
using Persona_Entidades;
using System;
using System.Collections.Generic;

namespace Seguridad_Entidades
{
    public class SEG_UsuarioEL
    {
        public String codigoUsuario { get; set; } 
        public String Perfil { get; set; }
        public String codigoTipoAcceso { get; set; }
        public PER_PersonalEL Persona { get; set; }
        public List<CMM_TipoAccesoEL> Permisos { get; set; }

        public Boolean Estado { get; set; }
    }
}
 