using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAppColegio.Models.Request;
using WebAppColegio.Models.Response;

namespace WebAppColegio.Controllers
{
    public class ForoController : Controller
    {

        private ILogger<ForoController> _logger;
        private IConfiguration _Configure;
        private string apiBaseUrl;
        private readonly ISession session;
        public ForoController(ILogger<ForoController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
            this.session = httpContextAccessor.HttpContext.Session;
        }
        public async Task<IActionResult> Index(String inserto = "")
        {
            try
            {

                var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
                ViewBag.nombreCurso = HttpContext.Session.GetString("cursoNombreSession");
                if (usuario == null)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                using (HttpClient client = new HttpClient())
                {
                    var foroRequest = new ForoRequest()
                    {
                        codigoClase = HttpContext.Session.GetString("claseSession"),
                        codigoUsuario = usuario.codigoUsuario
                    };
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(apiBaseUrl + "/educacion/foro"),
                        Content = new StringContent(JsonConvert.SerializeObject(foroRequest), Encoding.UTF8, "application/json")
                    };
                    using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        List<ForoResponse> _foroResponseLst = new List<ForoResponse>();
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var data = await Response.Content.ReadAsStringAsync();
                            _foroResponseLst = JsonConvert.DeserializeObject<List<ForoResponse>>(data);
                            return View(_foroResponseLst);
                        }
                        else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Info", "Sin foro asociado");
                            return View(_foroResponseLst);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return RedirectToAction("Login", "Intranet");
            }

        }
        public async Task<IActionResult> Detalle(String codigoForo)
        {
            try
            {
                var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
                ViewBag.nombreCurso = HttpContext.Session.GetString("cursoNombreSession");
                if (usuario == null)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                using (HttpClient client = new HttpClient())
                {
                    var foroRequest = new ForoRequest()
                    {
                        codigoClase = HttpContext.Session.GetString("claseSession"),
                        codigoUsuario = usuario.codigoUsuario,
                        codigoForo = codigoForo
                    };
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(apiBaseUrl + "/educacion/foro-detalle"),
                        Content = new StringContent(JsonConvert.SerializeObject(foroRequest), Encoding.UTF8, "application/json")
                    };
                    using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        List<ForoBase> _foroBaseLst = new List<ForoBase>();
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var data = await Response.Content.ReadAsStringAsync();
                            _foroBaseLst = JsonConvert.DeserializeObject<List<ForoBase>>(data);
                            return View(_foroBaseLst);
                        }
                        else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Info", "Sin foro asociado");
                            return View(_foroBaseLst);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return RedirectToAction("Login", "Intranet");
            }

        }

        public async Task<IActionResult> Create(String codigoForo, String codigoClase, String inputForo, String tema)
        {
            try
            {
                var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
                ViewBag.nombreCurso = HttpContext.Session.GetString("cursoNombreSession");
                if (usuario == null)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                using (HttpClient client = new HttpClient())
                {
                    var foroRequest = new ForoRequest()
                    {
                        codigoClase = HttpContext.Session.GetString("claseSession"),
                        tema = tema == null ? "" : tema,
                        descripcion = HttpUtility.HtmlEncode(inputForo),
                        temaPadre = codigoForo == null ? "" : codigoForo,
                        codigoUsuario = usuario.codigoUsuario
                    };
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(apiBaseUrl + "/educacion/foro"),
                        Content = new StringContent(JsonConvert.SerializeObject(foroRequest), Encoding.UTF8, "application/json")
                    };
                    using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        BaseResponse response = new BaseResponse();
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var data = await Response.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<BaseResponse>(data);
                            if (codigoForo == null)
                                return RedirectToAction("Index", "Foro");
                            return RedirectToAction("Detalle", "Foro", new { codigoForo = codigoForo });
                        }
                        else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            return RedirectToAction("Detalle", "Foro");
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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return RedirectToAction("Login", "Intranet");
            }

        }

    }
}
