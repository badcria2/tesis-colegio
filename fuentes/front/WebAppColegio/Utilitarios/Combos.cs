using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAppColegio.Models.Request;
using WebAppColegio.Models.Response;

namespace WebAppColegio.Utilitarios
{
    public static class Combos
    {
        public static async Task<SelectList> LstComboSeccion(String usuario, String api, String codigo, String perfil)
        {
            var lstSeccion = new List<Combo>();

            using (HttpClient client = new HttpClient())
            {
                var baseRequest = new ComboRequest()
                {
                    codigoUsuario = usuario,
                    codigo = codigo,
                    perfil = perfil
                };
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(api + "/utilitario/seccion"),
                    Content = new StringContent(JsonConvert.SerializeObject(baseRequest), Encoding.UTF8, "application/json")
                };
                using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await Response.Content.ReadAsStringAsync();
                        lstSeccion = JsonConvert.DeserializeObject<List<Combo>>(data);
                    }
                }

            }
            lstSeccion.Insert(0, new Combo() { codigo = "Todos", descripcion = "Todos" });
            return new SelectList(lstSeccion, "codigo", "descripcion");

        }

        public static async Task<SelectList> LstComboGrado(String usuario, String api, String perfil)
        {
            var lstGrado = new List<Combo>();

            using (HttpClient client = new HttpClient())
            {
                var baseRequest = new ComboRequest()
                {
                    codigoUsuario = usuario,
                    perfil = perfil
                };
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(api + "/utilitario/grado"),
                    Content = new StringContent(JsonConvert.SerializeObject(baseRequest), Encoding.UTF8, "application/json")
                };
                using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await Response.Content.ReadAsStringAsync();
                        lstGrado = JsonConvert.DeserializeObject<List<Combo>>(data);
                    }
                }

            }
            lstGrado.Insert(0, new Combo() { codigo = "Todos", descripcion = "Todos" });
            return new SelectList(lstGrado, "codigo", "descripcion");

        }
    }
}
