using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealityFirst.Controllers
{
    public class LogInController : Controller
    {
        public ActionResult IniciarSesion()
        {
            return View();
        }

        public ActionResult CrearCuenta()
        {
            return View();
        }

        
    }
}
