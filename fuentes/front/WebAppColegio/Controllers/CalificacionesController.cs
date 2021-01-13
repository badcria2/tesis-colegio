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
using WebAppColegio.Models;
using WebAppColegio.Models.Request;
using WebAppColegio.Models.Response;
using WebAppColegio.Utilitarios;

namespace WebAppColegio.Controllers
{
    public class CalificacionesController : Controller
    {
        private ILogger<CalificacionesController> _logger;
        private IConfiguration _Configure;
        private string apiBaseUrl;
        private readonly ISession session;
        public CalificacionesController(ILogger<CalificacionesController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
            this.session = httpContextAccessor.HttpContext.Session;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));

                ViewBag.ListaSeccion = new SelectList(await Combos.LstComboSeccion(usuario.codigoUsuario, apiBaseUrl, "", usuario.perfil),
                              "Value",
                              "Text");
                ViewBag.ListaGrados = new SelectList(await Combos.LstComboGrado(usuario.codigoUsuario, apiBaseUrl, usuario.perfil),
                              "Value",
                              "Text");

                if (usuario == null)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                return View();

            }
            catch (Exception e)
            {
                return RedirectToAction("Login", "Intranet");
            }

        }

        [HttpPost]
        [ActionName("listarNotas")]
        public async Task<ActionResult> ListarNotasAsync(String _periodo, String _clase)
        {
            try
            {
                var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
                if (usuario == null) //si el usuario se enuentra
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return View("Login", "Intranet");
                }

                return await buscarCalificacionesAsync(_periodo, _clase, usuario.perfil, usuario.codigoUsuario);

            }
            catch (Exception e)
            {
                return PartialView("Login", "Intranet");
            }
        }

        public async Task<ActionResult> buscarCalificacionesAsync(String periodo, String clase, String perfil, String codigoUsuario, String page = "")
        {
            using (HttpClient client = new HttpClient())
            {
                var baseRequest = new CursoMRequest()
                {
                    codigoUsuario = codigoUsuario,
                    periodo = periodo,
                    clase = clase
                };
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(apiBaseUrl + (perfil.Equals("Docente") ? "/servicio/notas-docente" : "/servicio/notas")),
                    Content = new StringContent(JsonConvert.SerializeObject(baseRequest), Encoding.UTF8, "application/json")
                };
                using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await Response.Content.ReadAsStringAsync();
                        if (page.Equals(""))
                        {
                            if (perfil.Equals("Docente"))
                            {

                                List<NotasAlumnoResponse> _notasResponseLst = new List<NotasAlumnoResponse>();
                                _notasResponseLst = JsonConvert.DeserializeObject<List<NotasAlumnoResponse>>(data);
                                return PartialView("NotasDocente", _notasResponseLst);
                            }
                            else
                            {
                                List<NotasResponse> _notasResponseLst = new List<NotasResponse>();
                                _notasResponseLst = JsonConvert.DeserializeObject<List<NotasResponse>>(data);
                                return PartialView("ListarNotasAsync", _notasResponseLst);
                            }
                        }
                        else
                        {
                            return View("Index");
                        }
                    }
                    else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("Info", "Sin Cursos asociados");
                        return PartialView();
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("ErorData", "A ocurrido un error favor contactar con el administrador");
                        return PartialView(null);
                    }
                }

            }
        }



        [ActionName("ListarCursos")]
        public async Task<JsonResult> ListarCursosAsync(String _grado = "", String _seccion = "")
        {
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            using (HttpClient client = new HttpClient())
            {
                var cursoRequest = new CursoRequest()
                {
                    periodo = DateTime.Now.Year.ToString(),
                    perfil = usuario.perfil,
                    grado = _grado,
                    seccion = _seccion,
                    usuario = usuario.codigoUsuario
                };
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(apiBaseUrl + "/servicio/obtener-cursos"),
                    Content = new StringContent(JsonConvert.SerializeObject(cursoRequest), Encoding.UTF8, "application/json")
                };
                using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    List<CursoResponse> _cursoResponseLst = new List<CursoResponse>();
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await Response.Content.ReadAsStringAsync();
                        _cursoResponseLst = JsonConvert.DeserializeObject<List<CursoResponse>>(data);
                    }
                    return Json(_cursoResponseLst);
                }

            }
        }


        [ActionName("ListarClases")]
        public async Task<JsonResult> ListarClases(String _grado = "")
        {
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            return Json(Combos.LstComboSeccion(usuario.codigoUsuario, apiBaseUrl, _grado, usuario.perfil));
        }

        [ActionName("Registrar")]
        public async Task<JsonResult> Registrar([FromBody] IEnumerable<NotaRequest> data)
        {
            List<NotaRequest> infor = data.ToList();
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            using (HttpClient client = new HttpClient())
            {
                var requestSend = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(apiBaseUrl + "/servicio/registrar-notas"),
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
