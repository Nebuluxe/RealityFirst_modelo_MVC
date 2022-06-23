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
    public class EventoController : Controller
    {
        IConfiguration config;
        EventoServicio evento;

        public EventoController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("DBRealityFirst");
            evento = new EventoServicio(ConnectionString);

        }

        public IActionResult Eventos(int id)
        {
            IList<EventoModel> lista = evento.GetAll(id);
            return View("Eventos", lista);
        }
    }
}
