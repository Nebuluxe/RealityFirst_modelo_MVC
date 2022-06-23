using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using RealityFirst.Models;
using RealityFirst.Servicio;
using Microsoft.Extensions.Configuration;

namespace RealityFirst.Controllers
{
    public class ArtistaController : Controller
    {
        IConfiguration config;
        ArtistaServicio artista;

        public ArtistaController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("DBRealityFirst");
            artista = new ArtistaServicio(ConnectionString);
        }

        public IActionResult Artista()
        {
            IList<ArtistaModel> lista = artista.GetAll();
            return View("Artista", lista);
        }

        public IActionResult Ficha_artista(int id)
        {
            ArtistaModel Obj = artista.Get(id);
            return View(Obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
