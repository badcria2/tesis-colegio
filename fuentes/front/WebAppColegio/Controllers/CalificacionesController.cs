using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAppColegio.Models;
using WebAppColegio.Models.Request;
using WebAppColegio.Models.Response;

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
                if (usuario == null) //si el usuario se enuentra
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                return View();
                //return await buscarCalificacionesAsync("", usuario.codigoUsuario,"index");

            }
            catch (Exception e)
            {
                return RedirectToAction("Login", "Intranet");
            }

        }

        [HttpPost]
        [ActionName("listarNotas")]
        public async Task<ActionResult> ListarNotasAsync(String _periodo)
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
               
                return await buscarCalificacionesAsync(_periodo, usuario.codigoUsuario);

            }
            catch (Exception e)
            {
                return PartialView("Login", "Intranet");
            }
        }

        public async Task<ActionResult> buscarCalificacionesAsync(String periodo, String codigoUsuario, String page= "")
        {
            using (HttpClient client = new HttpClient())
            {
                var baseRequest = new BaseRequest()
                {
                    codigoUsuario = codigoUsuario,
                    periodo = periodo
                };
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(apiBaseUrl + "/servicio/notas"),
                    Content = new StringContent(JsonConvert.SerializeObject(baseRequest), Encoding.UTF8, "application/json")
                };
                using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    List<NotasResponse> _notasResponseLst = new List<NotasResponse>();
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await Response.Content.ReadAsStringAsync();
                        _notasResponseLst = JsonConvert.DeserializeObject<List<NotasResponse>>(data);
                        if (page.Equals(""))
                        {
                            return PartialView("ListarNotasAsync", _notasResponseLst);
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
                        return PartialView(_notasResponseLst);
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

    }

}
