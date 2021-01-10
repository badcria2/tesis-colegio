using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using WebAppColegio.Models.Response;

namespace WebAppColegio.Utilitarios
{
    public static class Combos
    {
        public static SelectList lstComboGrado()
        {
            var lstGrado = new List<Combo>();
            lstGrado.Add(new Combo() { codigo = "Todos", descripcion = "Todos" });
            lstGrado.Add(new Combo() { codigo = "1", descripcion = "1º Grado" });
            lstGrado.Add(new Combo() { codigo = "2", descripcion = "2º Grado" });
            lstGrado.Add(new Combo() { codigo = "3", descripcion = "3º Grado" });
            lstGrado.Add(new Combo() { codigo = "4", descripcion = "4º Grado" });
            lstGrado.Add(new Combo() { codigo = "5", descripcion = "5º Grado" }); 

            return new SelectList(lstGrado, "codigo", "descripcion");
 
        }
        public static SelectList lstComboSeccion()
        { 
            var lstSeccion = new List<Combo>();
            lstSeccion.Add(new Combo() { codigo = "Todos", descripcion = "Todos" });
            lstSeccion.Add(new Combo() { codigo = "A", descripcion = "Sección A" });
            lstSeccion.Add(new Combo() { codigo = "B", descripcion = "Sección B" });
            lstSeccion.Add(new Combo() { codigo = "C", descripcion = "Sección C" });  
            return new SelectList(lstSeccion, "codigo", "descripcion"); 
        }
    }
}
