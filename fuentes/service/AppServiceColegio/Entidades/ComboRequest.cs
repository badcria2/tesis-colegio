using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceColegio.Entidades
{
    public class ComboRequest : BaseRequest
    {
        public String codigo { get; set; }
        public String perfil { get; set; }
    }
}
