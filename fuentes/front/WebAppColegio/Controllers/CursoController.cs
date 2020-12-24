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
using WebAppColegio.Models.Response;

namespace WebAppColegio.Controllers
{
    public class CursoController : Controller
    {
        private ILogger<CursoController> _logger;
        private IConfiguration _Configure;
        private string apiBaseUrl;
        private readonly ISession session;
        public CursoController(ILogger<CursoController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
            this.session = httpContextAccessor.HttpContext.Session;
        }



        public async Task<IActionResult> Index(String _codigoUsuario)
        {
            try
            {
                if (HttpContext.Session.GetString("UsuarioSession") == null) //si el usuario se enuentra
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                using (HttpClient client = new HttpClient())
                {
                    // var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
                    var cursoRequest = new CursoRequest()
                    {
                        periodo = DateTime.Now.Year.ToString(),
                        usuario = _codigoUsuario
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
                            return View(_cursoResponseLst);
                        }
                        else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Info", "Sin Cursos asociados");
                            return View(_cursoResponseLst);
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
            catch (Exception e)
            {
                return RedirectToAction("Login", "Intranet");
            }

        }

        public async Task<IActionResult> Detalle(String _codigoCurso)
        {
            try
            {
                if (HttpContext.Session.GetString("UsuarioSession") == null) //si el usuario se enuentra
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                return View();
                //using (HttpClient client = new HttpClient())
                //{
                // var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
                //var cursoRequest = new CursoRequest()
                //{
                //    periodo = DateTime.Now.Year.ToString(),
                //    usuario = _codigoCurso
                //};
                //var request = new HttpRequestMessage
                //{
                //    Method = HttpMethod.Get,
                //    RequestUri = new Uri(apiBaseUrl + "/servicio/detalle-cursos"),
                //    Content = new StringContent(JsonConvert.SerializeObject(cursoRequest), Encoding.UTF8, "application/json")
                //};
                //using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                //{
                //    List<CursoResponse> _cursoResponseLst = new List<CursoResponse>();
                //    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                //    {
                //        var data = await Response.Content.ReadAsStringAsync();
                //        _cursoResponseLst = JsonConvert.DeserializeObject<List<CursoResponse>>(data);
                //        return View(_cursoResponseLst);
                //    }
                //    else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                //    {
                //        ModelState.Clear();
                //        ModelState.AddModelError("Info", "Sin Cursos asociados");
                //        return View(_cursoResponseLst);
                //    }
                //    else
                //    {
                //        ModelState.Clear();
                //        ModelState.AddModelError("ErorData", "A ocurrido un error favor contactar con el administrador");
                //        return RedirectToAction("Login", "Intranet");
                //    }
                //}

                //}


            }
            catch (Exception e)
            {
                return RedirectToAction("Login", "Intranet");
            }

        }
    }
}
