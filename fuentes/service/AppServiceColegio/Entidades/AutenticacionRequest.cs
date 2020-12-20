using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceColegio.Entidades
{
    public class AutenticacionRequest
    {
        public String Usuario { get; set; }
        public String Password { get; set; }
    }
}
