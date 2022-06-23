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
    public class EventosController : Controller
    {
        IConfiguration config;
        EventosServicio eventos;

        public EventosController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("DBRealityFirst");
            eventos = new EventosServicio(ConnectionString);
        }

        public IActionResult Evento_artista(int id)
        {
            EventosModel evento = eventos.Get(id);
            return View(evento);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}