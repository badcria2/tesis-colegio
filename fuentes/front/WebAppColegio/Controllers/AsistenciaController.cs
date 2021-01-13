using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAppColegio.Models.Request;
using WebAppColegio.Models.Response;
using WebAppColegio.Utilitarios;

namespace WebAppColegio.Controllers
{
    public class AsistenciaController : Controller
    {
        private ILogger<AsistenciaController> _logger;
        private IConfiguration _Configure;
        private string apiBaseUrl;
        private readonly ISession session;
        public AsistenciaController(ILogger<AsistenciaController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
            this.session = httpContextAccessor.HttpContext.Session;
        }
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));

                ViewBag.ListaSeccion = new SelectList(await Combos.LstComboSeccion(usuario.codigoUsuario, apiBaseUrl, "Todos", usuario.perfil),
                              "Value",
                              "Text");
                ViewBag.ListaGrados = new SelectList(await Combos.LstComboGrado(usuario.codigoUsuario, apiBaseUrl, usuario.perfil),
                              "Value",
                              "Text");
                return View();

            }
            catch (Exception e)
            {
                return RedirectToAction("Login", "Intranet");
            }
        }

        public async Task<ActionResult> ListarAsistencia(String _clase, String _fechaRegistro, String _periodo = "")
        {
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));

            using (HttpClient client = new HttpClient())
            {
                var baseRequest = new AsistenciaRequest()
                {
                    codigoUsuario = "",
                    periodo = String.Empty.Equals(_periodo) ? DateTime.Now.Year.ToString() : _periodo,
                    clase = _clase,
                    fechaRegistro = String.Empty.Equals(_fechaRegistro) ? DateTime.Now.ToString("dd/MM/yyyy") : _fechaRegistro,
                };
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(apiBaseUrl + "/educacion/asistencia"),
                    Content = new StringContent(JsonConvert.SerializeObject(baseRequest), Encoding.UTF8, "application/json")
                };
                using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    List<AsistenciaResponse> asistenciaResponse = new List<AsistenciaResponse>();
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await Response.Content.ReadAsStringAsync();
                        asistenciaResponse = JsonConvert.DeserializeObject<List<AsistenciaResponse>>(data);
                        return PartialView("ListarAsistencia", asistenciaResponse);

                    }
                    else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("Info", "Sin Asistencia");
                        return PartialView(asistenciaResponse);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("ErorData", "A ocurrido un error favor contactar con el administrador");
                        return RedirectToAction("Login", "Intranet");
                    }
                }

            }
        }

        [ActionName("Registrar")]
        public async Task<JsonResult> Registrar([FromBody] IEnumerable<AsistenciaRequest> data)
        {
            List<AsistenciaRequest> infor = data.ToList();
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            using (HttpClient client = new HttpClient())
            {
                var requestSend = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(apiBaseUrl + "/educacion/asistencia"),
                    Content = new StringContent(JsonConvert.SerializeObject(infor), Encoding.UTF8, "application/json")
                };
                using (var Response = await client.SendAsync(requestSend).ConfigureAwait(false))
                {
                    var baseResponse = new BaseResponse();
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var resp = await Response.Content.ReadAsStringAsync();
                        baseResponse = JsonConvert.DeserializeObject<BaseResponse>(resp);
                    }
                    return Json(baseResponse);
                }

            }
        }
    }
}
