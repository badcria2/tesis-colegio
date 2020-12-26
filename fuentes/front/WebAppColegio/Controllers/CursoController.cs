using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using WebAppColegio.Models;
using WebAppColegio.Models.Request;
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

        public async Task<IActionResult> Detalle(String curso, String clase, String cursoNombre)
        {
            try
            {
                if (HttpContext.Session.GetString("UsuarioSession") == null) //si el usuario se enuentra
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                HttpContext.Session.SetString("claseSession", curso);
                HttpContext.Session.SetString("cursoSession", clase);
                HttpContext.Session.SetString("cursoNombreSession", cursoNombre);
                using (HttpClient client = new HttpClient())
                {
                    var cursoRequest = new MaterialRequest()
                    {
                        periodo = DateTime.Now.Year.ToString(),
                        codigoClase = clase
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
        public async Task<IActionResult> Create(IFormFile files)
        {
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            string blobstorageconnection = _Configure.GetValue<string>("blobstorage");
            string systemFileName = usuario.codigoUsuario + "_" + files.FileName;
            // Retrieve storage account from connection string.
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            // Create the blob client.
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("alumnocontainer");
            // This also does not make a service call; it only creates a local object.
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
            await using (var data = files.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }
             
            return RedirectToAction("Detalle", "Curso", new { clase = HttpContext.Session.GetString("claseSession"), curso = HttpContext.Session.GetString("cursoSession"), cursoNombre = HttpContext.Session.GetString("cursoNombreSession") });
        }

        public async Task<IActionResult> Download(string blobName)
        {
            CloudBlockBlob blockBlob;
            await using (MemoryStream memoryStream = new MemoryStream())
            {
                string blobstorageconnection = _Configure.GetValue<string>("blobstorage");
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("alumnocontainer");
                blockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);
                await blockBlob.DownloadToStreamAsync(memoryStream);
            }

            Stream blobStream = blockBlob.OpenReadAsync().Result;
            return File(blobStream, blockBlob.Properties.ContentType, blockBlob.Name);
        }
        public async Task<IActionResult> EliminarArchivo(string blobName)
        {
            var usuario = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
            string blobstorageconnection = _Configure.GetValue<string>("blobstorage");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            string strContainerName = "alumnocontainer";
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
            var blob = cloudBlobContainer.GetBlobReference(blobName);
            await blob.DeleteIfExistsAsync();
            return RedirectToAction("Detalle", "Curso", new { clase = HttpContext.Session.GetString("claseSession"), curso = HttpContext.Session.GetString("cursoSession"), cursoNombre = HttpContext.Session.GetString("cursoNombreSession") });

        }
    }
}
