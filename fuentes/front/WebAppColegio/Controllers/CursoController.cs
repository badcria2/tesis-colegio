using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using WebAppColegio.Models;
using WebAppColegio.Models.Request;
using WebAppColegio.Models.Response;
using WebAppColegio.Utilitarios;

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



        public async Task<IActionResult> IndexAsync(String _codigoUsuario = "")
        {
            try
            {
                var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));

                ViewBag.ListaGrados = new SelectList(await Combos.LstComboGrado(usuario.codigoUsuario, apiBaseUrl, usuario.perfil),
                              "Value",
                              "Text");
                ViewBag.ListaSeccion = new SelectList(await Combos.LstComboSeccion(usuario.codigoUsuario, apiBaseUrl, "Todos", usuario.perfil),
                              "Value",
                              "Text");
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Login", "Intranet");
            }

        }


        public async Task<IActionResult> Detalle(String curso, String clase, String cursoNombre)
        {
            try
            {

                var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
                if (HttpContext.Session.GetString("UsuarioSession") == null) //si el usuario se enuentra
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                HttpContext.Session.SetString("claseSession", clase);
                HttpContext.Session.SetString("cursoSession", curso);
                HttpContext.Session.SetString("cursoNombreSession", cursoNombre);
                using (HttpClient client = new HttpClient())
                {
                    var cursoRequest = new CursoMRequest()
                    {
                        periodo = DateTime.Now.Year.ToString(),
                        clase = clase,
                        codigoUsuario = usuario.codigoUsuario
                    };
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(apiBaseUrl + "/servicio/curso-detalle"),
                        Content = new StringContent(JsonConvert.SerializeObject(cursoRequest), Encoding.UTF8, "application/json")
                    };
                    using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        CursoDetalleResponse cursoDetalleResponse = new CursoDetalleResponse();
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var data = await Response.Content.ReadAsStringAsync();
                            cursoDetalleResponse = JsonConvert.DeserializeObject<CursoDetalleResponse>(data);
                            cursoDetalleResponse.cursoNombre = cursoNombre;
                            return View(cursoDetalleResponse);
                        }
                        else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Info", "Sin Cursos asociados");
                            return View(cursoDetalleResponse);
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

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile files, int semana, String mes)
        {
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            if (null != files)
            {
                using (HttpClient client = new HttpClient())
                {
                    var cursoRequest = new DocumentoRequest()
                    {
                        nombre = usuario.codigoUsuario + "_" + files.FileName.Replace(" ", "-"),
                        codigoClase = HttpContext.Session.GetString("claseSession"),
                        origen = usuario.perfil,
                        semana = semana,
                        mes = mes,
                        usuario = usuario.codigoUsuario
                    };
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(apiBaseUrl + "/educacion/documento"),
                        Content = new StringContent(JsonConvert.SerializeObject(cursoRequest), Encoding.UTF8, "application/json")
                    };
                    using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            await CargarDocumentoAzureAsync(usuario, files);
                            return RedirectToAction("Detalle", "Curso", new { clase = HttpContext.Session.GetString("claseSession"), curso = HttpContext.Session.GetString("cursoSession"), cursoNombre = HttpContext.Session.GetString("cursoNombreSession") });

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
            else { return RedirectToAction("Detalle", "Curso", new { clase = HttpContext.Session.GetString("claseSession"), curso = HttpContext.Session.GetString("cursoSession"), cursoNombre = HttpContext.Session.GetString("cursoNombreSession") }); }

        }
        public async Task CargarDocumentoAzureAsync(AutenticacionResponse usuario, IFormFile archivo)
        {
            string blobstorageconnection = _Configure.GetValue<string>("blobstorage");
            string systemFileName = usuario.codigoUsuario + "_" + archivo.FileName.Replace(" ", "-");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("alumnocontainer");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
            await using (var data = archivo.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }
        }
        public async Task<IActionResult> Download(string blobName, String container)
        {
            CloudBlockBlob blockBlob;
            await using (MemoryStream memoryStream = new MemoryStream())
            {
                string blobstorageconnection = _Configure.GetValue<string>("blobstorage");
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(container);
                blockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
                await blockBlob.DownloadToStreamAsync(memoryStream);
            }

            Stream blobStream = blockBlob.OpenReadAsync().Result;
            return File(blobStream, blockBlob.Properties.ContentType, blockBlob.Name);
        }

        public async Task<IActionResult> EliminarArchivo(string blobName, String codigo, String tipo, String container)
        {
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            string blobstorageconnection = _Configure.GetValue<string>("blobstorage");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            using (HttpClient client = new HttpClient())
            {
                var tareaRequest = new TareaRequest()
                {
                    codigo = codigo,
                    tipo = tipo
                };
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(apiBaseUrl + "/educacion/delete-documento"),
                    Content = new StringContent(JsonConvert.SerializeObject(tareaRequest), Encoding.UTF8, "application/json")
                };
                using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(container);
                        var blob = cloudBlobContainer.GetBlobReference(blobName);
                        await blob.DeleteIfExistsAsync();
                        return RedirectToAction("Detalle", "Curso", new { clase = HttpContext.Session.GetString("claseSession"), curso = HttpContext.Session.GetString("cursoSession"), cursoNombre = HttpContext.Session.GetString("cursoNombreSession") });

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




        [HttpPost]
        [ActionName("CursosDetalle")]
        public async Task<ActionResult> CursosDetalle(String _codigoUsuario = "", String _grado = "", String _seccion = "")
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

                return await ListarCursos(_codigoUsuario, _grado, _seccion);

            }
            catch (Exception e)
            {
                return PartialView("Login", "Intranet");
            }
        }

        public async Task<ActionResult> ListarCursos(String _codigoUsuario = "", String _grado = "", String _seccion = "")
        {
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            if (usuario == null) //si el usuario se enuentra
            {
                ModelState.Clear();
                ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                return RedirectToAction("Login", "Intranet");
            }
            using (HttpClient client = new HttpClient())
            {
                var cursoRequest = new CursoRequest()
                {
                    periodo = DateTime.Now.Year.ToString(),
                    perfil = usuario.perfil,
                    grado = _grado,
                    seccion = _seccion,
                    usuario = _codigoUsuario.Equals("") ? usuario.codigoUsuario : _codigoUsuario
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
                        return PartialView("CursosDetalle", _cursoResponseLst);
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

        [ActionName("ListarSeccion")]
        public async Task<SelectList> ListarSeccion(String _grado = "")
        {
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            return new SelectList(await Combos.LstComboSeccion(usuario.codigoUsuario, apiBaseUrl, _grado, usuario.perfil),
                            "Value",
                            "Text");
        }

    }
}
