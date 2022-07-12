using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using RealityFirst.Models;
using RealityFirst.Servicio;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Index()
        {
            IList<ArtistaModel> lista = artista.GetAll();
            return View("index", lista);
        }

        public IActionResult Artista()
        {
            IList<ArtistaModel> lista = artista.GetAll();
            return View("Artista", lista);
        }

        public IActionResult Ficha_artista(int id)
        {
            ArtistaModel obj_artista = artista.Get(id);
            return View(obj_artista);
        }

    }
}
