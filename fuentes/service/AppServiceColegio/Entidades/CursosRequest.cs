using System;

namespace AppServiceColegio.Entidades
{

    public class CursosRequest : BaseRequest
    {
        public String codigo { get; set; }
        public String perfil { get; set; }
        public String grado { get; set; }
        public String seccion { get; set; }
       


    }
}
