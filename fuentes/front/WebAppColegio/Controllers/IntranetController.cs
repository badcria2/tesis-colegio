using System; 
using System.Net.Http;
using System.Text;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAppColegio.Models;
using WebAppColegio.Models.Response;

namespace WebAppColegio.Controllers
{
    public class IntranetController : Controller
    {
        private ILogger<IntranetController> _logger;
        private IConfiguration _Configure;
        private string apiBaseUrl;

        public IntranetController(ILogger<IntranetController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;

            apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        }
        // GET: IntranetController
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        public ViewResult AddReservation() => View();

        [HttpPost]
        public async Task<IActionResult> Login(AutenticacionRequest autenticacionRequest)
        {
            try
            { 
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(autenticacionRequest), Encoding.UTF8, "application/json");
                    string endpoint = apiBaseUrl + "/seguridad/autenticacion";
                    using (var Response = await client.PostAsync(endpoint, content))
                    {
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            
                            var data = await Response.Content.ReadAsStringAsync();
                            AutenticacionResponse autenticacionResponse = JsonConvert.DeserializeObject<AutenticacionResponse>(data); 
                            TempData["Profile"] = JsonConvert.SerializeObject(autenticacionResponse);
                            return RedirectToAction("Principal", "Intranet", autenticacionResponse);
                        }
                        else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("ErrorLogeo", "Usuario/Password incorrectos");
                            return View();
                        }
                        else if(Response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("ErrorLogeo", "A ocurrido un error favor contactar con el administrador");
                            return View();
                        }
                        else
                        {
                            return View();
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public ActionResult Principal(AutenticacionResponse autenticacionResponse)
        {
            try
            {
                if (autenticacionResponse != null) //si el usuario se enuentra
                {
                    TempData["Profile"] = JsonConvert.SerializeObject(autenticacionResponse);
                    return View();
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            { 
                return View();
            }

        }
    }
}
