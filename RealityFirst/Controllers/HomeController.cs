using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using RealityFirst.Models;
using RealityFirst.Servicio;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace RealityFirst.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration config;
        ArtistaServicio artista;

        public HomeController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("DBRealityFirst");
            artista = new ArtistaServicio(ConnectionString);

        }
        public IActionResult Index()
        {
            IList<ArtistaModel> lista = artista.GetAll();
            return View("index", lista);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult IniciarSesion()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToAction("Login","Acceso");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
