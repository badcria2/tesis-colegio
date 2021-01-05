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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using WebAppColegio.Models.Request;
using WebAppColegio.Models.Response;

namespace WebAppColegio.Controllers
{
    public class AvisoController : Controller
    {
        private ILogger<AvisoController> _logger;
        private IConfiguration _Configure;
        private string apiBaseUrl;
        private readonly ISession session;
        public AvisoController(ILogger<AvisoController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
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
                using (HttpClient client = new HttpClient())
                {

                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(apiBaseUrl + "/servicio/avisos"),
                        Content = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json")
                    };
                    using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        List<AvisosResponse> _avisosResponsLst = new List<AvisosResponse>();
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var data = await Response.Content.ReadAsStringAsync();
                            _avisosResponsLst = JsonConvert.DeserializeObject<List<AvisosResponse>>(data);

                            foreach (var item in _avisosResponsLst)
                            {
                                item.uri = VerImagenes(item.imagen);
                            }
                            return View(_avisosResponsLst);
                        }
                        else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Info", "Sin avisos");
                            return View(_avisosResponsLst);
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

        public String VerImagenes(String archivo)
        {
            string blobstorageconnection = _Configure.GetValue<string>("blobstorage");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("avisocontainer");
            var blobReference = container.GetBlockBlobReference(archivo.Split('\\').Last());
            blobReference.Properties.ContentType = "image/jpeg";

            BlobContinuationToken continuationToken = null;

            var response = container.ListBlobsSegmentedAsync(continuationToken);

            foreach (var item in response.Result.Results)
            {

            }

            return response.Result.Results.Where(p => p.Uri.AbsolutePath.ToString().Replace("/avisocontainer/", "") == archivo).Select(X => X.Uri.ToString()).FirstOrDefault();
        }

        public async Task<ActionResult> Create(String titulo, String contenido, IFormFile imagen, String inputfondospan, String codigoAviso, String fechaInicio, String fechaFin)
        {
            try
            {
                var usuarioLogueado = JsonConvert.DeserializeObject<AutenticacionResponse>(HttpContext.Session.GetString("UsuarioSession"));
                if (usuarioLogueado == null) //si el usuario se enuentra
                {
                    ModelState.Clear();
                    ModelState.AddModelError("ErrorLogeo", "Tiempo sesión expirado");
                    return RedirectToAction("Login", "Intranet");
                }
                using (HttpClient client = new HttpClient())
                {
                    var avisoRequest = new AvisoRequest()
                    {
                        codigoAviso = codigoAviso,
                        contenido = contenido,
                        fechaFin = fechaFin,
                        fechaInicio = fechaInicio,
                        imagen = null == imagen ? inputfondospan : usuarioLogueado.codigoUsuario + "_" + imagen.FileName.Replace(" ", "-"),
                        titulo = titulo,
                        usuario = usuarioLogueado.codigoUsuario
                    };
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(apiBaseUrl + "/servicio/avisos"),
                        Content = new StringContent(JsonConvert.SerializeObject(avisoRequest), Encoding.UTF8, "application/json")
                    };
                    using (var Response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        BaseResponse baseResponse = new BaseResponse();
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var data = await Response.Content.ReadAsStringAsync();
                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(data);
                            if(imagen != null)
                                await CargarDocumentoAzureAsync(usuarioLogueado, imagen);

                            return RedirectToAction("Index");
                        }
                        else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Info", "Sin avisos");
                            return RedirectToAction("Index");
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

        public async Task CargarDocumentoAzureAsync(AutenticacionResponse usuario, IFormFile archivo)
        {
            string blobstorageconnection = _Configure.GetValue<string>("blobstorage");
            string systemFileName = usuario.codigoUsuario + "_" + archivo.FileName.Replace(" ", "-");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("avisocontainer");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
            await using (var data = archivo.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }
        }
    }

}
